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
        [DataRow(42010)]
        [DataRow(4201020)]
        public void GetNamesByCodeShouldThrow(int code)
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                ChinaAreaHelper.Get(code);
            });
        }
    }
}