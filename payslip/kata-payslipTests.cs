using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace kata_payslip
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void CalculateTax_Test()
        {
            TaxCalculator test = new TaxCalculator();
            Assert.AreEqual(test.CalculateTax(60050), 922);
        }
    }
}
