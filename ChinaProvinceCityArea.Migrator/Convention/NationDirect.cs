using ChinaProvinceCityArea.Migrator.Types;

namespace ChinaProvinceCityArea.Migrator.Convention
{
    public static class NationDirect
    {
        public const string virtualZoneName = "市辖区";
        public static List<Division> GetNationDirectVirtualCity(List<Division> areas, List<Division> cities)
        {
            var res = new List<Division>();
            areas.ForEach(a =>
            {
                var cityCode = (int.Parse(a.Code) / 100 * 100).ToString();
                var city = cities.Find(c => c.Code == cityCode);
                if (city is null && !res.Any(d => d.Code == cityCode))
                    res.Add(new()
                    {
                        Code = cityCode,
                        Name = virtualZoneName
                    });
            });
            return res;
        }
    }
}
