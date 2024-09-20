using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaProvinceCityArea.Migrator.Convention
{
    public static class ProvinceDirect
    {
        public const string judgeByContaining = "直辖";
        public const string virtualZoneName = "直辖区县";
        public static bool CityIsProvinceDirectVirtualZone(string cityName)
        {
            return cityName.Contains(judgeByContaining);
        }
    }
}
