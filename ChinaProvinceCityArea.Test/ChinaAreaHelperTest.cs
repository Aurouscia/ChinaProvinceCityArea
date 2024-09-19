namespace ChinaProvinceCityArea.Test
{
    [TestClass]
    public class ChinaAreaHelperTest
    {
        [TestMethod]
        [DataRow(420000, "����ʡ", null, null)]
        [DataRow(640000, "���Ļ���������", null, null)]
        [DataRow(420100, "����ʡ", "�人��", null)]
        [DataRow(445300, "�㶫ʡ", "�Ƹ���", null)]
        [DataRow(420102, "����ʡ", "�人��", "������")]
        [DataRow(350681, "����ʡ", "������", "������")]
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