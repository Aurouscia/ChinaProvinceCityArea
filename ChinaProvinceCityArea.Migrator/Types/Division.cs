using System.Text.Json.Serialization;

namespace ChinaProvinceCityArea.Migrator.Types
{
    /// <summary>
    /// 省市区的属性交集
    /// </summary>
    internal class Division
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }
}
