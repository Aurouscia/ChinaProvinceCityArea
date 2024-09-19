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
    Stream targetStream;
    try
    {
        sourceStream = File.OpenRead(work.Source);
        targetStream = File.Create(work.Target);
    }
    catch (FileNotFoundException)
    {
        throw new Exception("请在MigrationSource目录中<npm install>");
    }

    var data = JsonSerializer.Deserialize<Division[]>(sourceStream);
    if (data is null || data.Length == 0)
        throw new Exception("数据读取异常");

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
    foreach (var area in data)
    {
        targetWriter.WriteLine($"        {{ {area.Code}, \"{area.Name}\" }},");
    }
    targetWriter.WriteLine(tail);
    targetWriter.Flush();
    targetWriter.Close();
    Console.WriteLine($"成功写入 {data.Length} 条数据到 {work.ClassName}");
}

class Work(string source, string target, string className)
{
    public string Source { get; set; } = source;
    public string Target { get; set; } = target;
    public string ClassName { get; set; } = className;
}