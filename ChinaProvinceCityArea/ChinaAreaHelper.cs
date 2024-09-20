using ChinaProvinceCityArea.Data;

namespace ChinaProvinceCityArea
{
    /// <summary>
    /// 中国行政区划代码名称查询工具
    /// </summary>
    public static class ChinaAreaHelper
    {
        /// <summary>
        /// 获取省市区名称
        /// </summary>
        /// <param name="areaCode">6位行政区划代码，不需要市或区填00</param>
        /// <returns>行政区划名称</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static ChinaAreaHelperResult Get(int areaCode)
        {
            if (areaCode > 999999 || areaCode < 100000)
                throw new InvalidOperationException("行政区划代码应为6位");
            int provinceCode = areaCode / 10000 * 10000;
            int cityCode = areaCode / 100 * 100;
            ProvinceData.Data.TryGetValue(provinceCode, out string? provinceName);
            CityData.Data.TryGetValue(cityCode, out string? cityName);
            AreaData.Data.TryGetValue(areaCode, out string? areaName);
            return new ChinaAreaHelperResult()
            {
                ProvinceName = provinceName,
                CityName = cityName,
                AreaName = areaName
            };
        }
    }
    /// <summary>
    /// 获取行政区划名称结果
    /// </summary>
    public class ChinaAreaHelperResult
    {
        /// <summary>
        /// 省级行政区名
        /// </summary>
        public string? ProvinceName { get; set; }
        /// <summary>
        /// 地级行政区名
        /// </summary>
        public string? CityName { get; set; }
        /// <summary>
        /// 县级行政区名
        /// </summary>
        public string? AreaName { get; set; }
    }
}
