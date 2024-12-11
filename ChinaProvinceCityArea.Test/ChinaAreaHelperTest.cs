using ChinaProvinceCityArea.Migrator.Convention;

namespace ChinaProvinceCityArea.Test
{
    [TestClass]
    public class ChinaAreaHelperTest
    {
        [TestMethod]
        [DataRow(420000, "湖北省", null, null)]
        [DataRow(640000, "宁夏回族自治区", null, null)]
        [DataRow(420100, "湖北省", "武汉市", null)]
        [DataRow(445300, "广东省", "云浮市", null)]
        [DataRow(420102, "湖北省", "武汉市", "江岸区")]
        [DataRow(350681, "福建省", "漳州市", "龙海市")]
        [DataRow(500200, "重庆市", NationDirect.virtualZoneName, null)]
        [DataRow(429000, "湖北省", ProvinceDirect.virtualZoneName, null)]
        [DataRow(500238, "重庆市", NationDirect.virtualZoneName, "巫溪县")]
        [DataRow(429021, "湖北省", ProvinceDirect.virtualZoneName, "神农架林区")]
        public void GetNamesByCode(
            int code, string? provinceName, string? cityName, string? areaName)
        {
            var res = ChinaAreaHelper.Get(code);
            Assert.IsNotNull(res);
            Assert.AreEqual(provinceName, res.ProvinceName);
            Assert.AreEqual(cityName, res.CityName);
            Assert.AreEqual(areaName, res.AreaName);
        }

        [TestMethod]
        [DataRow(880000, true, true, true)]
        [DataRow(880100, true, true, true)]
        [DataRow(880102, true, true, true)]
        [DataRow(428800, false, true, true)]
        [DataRow(428802, false, true, true)]
        [DataRow(420188, false, false, true)]
        [DataRow(420088, false, true, true)]
        [DataRow(428888, false, true, true)]
        public void GetNamesByWrongCode(int code, bool provNull, bool cityNull, bool areaNull)
        {
            var res = ChinaAreaHelper.Get(code);
            Assert.IsNotNull(res);
            Assert.AreEqual(provNull, res.ProvinceName is null);
            Assert.AreEqual(cityNull, res.CityName is null);
            Assert.AreEqual(areaNull, res.AreaName is null);
        }

        [TestMethod]
        [DataRow(42010)]
        [DataRow(020102)]
        [DataRow(4201020)]
        public void GetNamesByCodeShouldReturnNull(int code)
        {
            Assert.IsNull(ChinaAreaHelper.Get(code));
        }
    }
}