using ChinaProvinceCityArea.Data;

namespace ChinaProvinceCityArea.Test
{
    [TestClass]
    public class StructureIntegrityTest
    {
        [TestMethod]
        public void MissingCity()
        {
            List<int> areaCodes = AreaData.Data.Keys.ToList();
            areaCodes.ForEach(code =>
            {
                var res = ChinaAreaHelper.Get(code);
                Assert.IsNotNull(res);
                Assert.IsNotNull(res.AreaName);
                //直辖市 和 省直辖区县 返回的CityName会为null
                //Assert.IsNotNull(res.CityName); 
                Assert.IsNotNull(res.ProvinceName);
            });
            int wrongCode = 420199;
            var res = ChinaAreaHelper.Get(wrongCode);
            Assert.IsNotNull(res);
            //区县名称 为null说明code有误
            Assert.IsNull(res.AreaName);
            Assert.IsNotNull(res.CityName); 
            Assert.IsNotNull(res.ProvinceName);
        }
    }
}
