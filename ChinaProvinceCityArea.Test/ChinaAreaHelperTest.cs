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