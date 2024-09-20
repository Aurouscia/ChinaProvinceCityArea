using ChinaProvinceCityArea.Migrator.Convention;
using ChinaProvinceCityArea.Migrator.Types;
using System.Text.Json;

string provinceSource = "../../../../MigrationSource/node_modules/@province-city-china/province/province.json";
string provinceTarget = "../../../../ChinaProvinceCityArea/Data/ProvinceData.cs";
string citySource =     "../../../../MigrationSource/node_modules/@province-city-china/city/city.json";
string cityTarget =     "../../../../ChinaProvinceCityArea/Data/CityData.cs";
string areaSource =     "../../../../MigrationSource/node_modules/@province-city-china/area/area.json";
string areaTarget =     "../../../../ChinaProvinceCityArea/Data/AreaData.cs";

List<Work> works = [
    new(provinceSource, provinceTarget, "ProvinceData"),
    new(citySource, cityTarget, "CityData"),
    new(areaSource, areaTarget, "AreaData"),
];


foreach (Work work in works)
{
    Stream sourceStream;
    try
    {
        sourceStream = File.OpenRead(work.Source);
    }
    catch (FileNotFoundException)
    {
        throw new Exception("请在MigrationSource目录中<npm install>");
    }

    var data = JsonSerializer.Deserialize<List<Division>>(sourceStream);
    if (data is null || data.Count == 0)
        throw new Exception("数据读取异常");
    work.Data = data;
}

var cities = works[1];
var areas = works[2];
var provinceDirectVirtualZoneCount = 0;
var nationDirectVirtualZoneCount = 0;
cities.Data.ForEach(c =>
{
    if (ProvinceDirect.CityIsProvinceDirectVirtualZone(c.Name))
    {
        c.Name = ProvinceDirect.virtualZoneName;
        provinceDirectVirtualZoneCount++;
    }
});
var nationDirect = NationDirect.GetNationDirectVirtualCity(areas.Data, cities.Data);
cities.Data.AddRange(nationDirect);
nationDirectVirtualZoneCount = nationDirect.Count;

foreach (var work in works) {
    Stream targetStream = File.Create(work.Target);
    var targetWriter = new StreamWriter(targetStream);
    var head =
        "namespace ChinaProvinceCityArea.Data;\r\n" +
        $"public class {work.ClassName}\r\n" +
        "{\r\n" +
        "    public static Dictionary<int, string> Data { get; set; } = new()\r\n" +
        "    {";
    var tail =
        "    };\r\n" +
        "}\r\n";
    targetWriter.WriteLine(head);
    foreach (var area in work.Data)
    {
        targetWriter.WriteLine($"        {{ {area.Code}, \"{area.Name}\" }},");
    }
    targetWriter.WriteLine(tail);
    targetWriter.Flush();
    targetWriter.Close();
    Console.WriteLine($"成功写入 {work.Data.Count} 条数据到 {work.ClassName}");
}
Console.WriteLine($"{nationDirectVirtualZoneCount} 个直辖市虚拟地级单位起名为 {ProvinceDirect.virtualZoneName}");
Console.WriteLine($"{provinceDirectVirtualZoneCount} 个省直辖县/自治区虚拟地级单位起名为 {NationDirect.virtualZoneName}");

class Work(string source, string target, string className)
{
    public string Source { get; set; } = source;
    public string Target { get; set; } = target;
    public string ClassName { get; set; } = className;
    public List<Division> Data { get; set; } = [];
}