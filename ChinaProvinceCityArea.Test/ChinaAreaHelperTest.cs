using ChinaProvinceCityArea.Migrator.Convention;

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
        [DataRow(500200, "������", NationDirect.virtualZoneName, null)]
        [DataRow(429000, "����ʡ", ProvinceDirect.virtualZoneName, null)]
        [DataRow(500238, "������", NationDirect.virtualZoneName, "��Ϫ��")]
        [DataRow(429021, "����ʡ", ProvinceDirect.virtualZoneName, "��ũ������")]
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
        [DataRow(880000)]
        [DataRow(880100)]
        [DataRow(880102)]
        [DataRow(428800)]
        [DataRow(428802)]
        [DataRow(420188)]
        [DataRow(420088)]
        [DataRow(428888)]
        public void GetNamesByWrongCode(int code)
        {
            var res = ChinaAreaHelper.Get(code);
            Assert.IsNull(res);
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