using ChinaProvinceCityArea.Data;
using ChinaProvinceCityArea.Migrator.Convention;

namespace ChinaProvinceCityArea.Test
{
    [TestClass]
    public class StructureIntegrityTest
    {
        [TestMethod]
        public void NoMissingCity()
        {
            List<int> areaCodes = AreaData.Data.Keys.ToList();
            areaCodes.ForEach(code =>
            {
                var res = ChinaAreaHelper.Get(code);
                Assert.IsNotNull(res);
                Assert.IsNotNull(res.AreaName);
                Assert.IsNotNull(res.CityName); 
                Assert.IsNotNull(res.ProvinceName);
            });
        }
        [TestMethod]
        public void VirtualCityCount()
        {
            List<string> cityNames = CityData.Data.Values.ToList();
            int provinceDirectCount = cityNames.Count(x => x == ProvinceDirect.virtualZoneName);
            int nationDirectCount = cityNames.Count(x => x == NationDirect.virtualZoneName);
            //四个省有省直辖区县虚拟地级
            Assert.AreEqual(4, provinceDirectCount);
            //五个直辖市虚拟地级（重庆有5001和5002两个）
            Assert.AreEqual(5, nationDirectCount);
        }
    }
}
