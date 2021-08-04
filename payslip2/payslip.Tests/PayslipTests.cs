using System;
using Xunit;
using PayslipGenerator;

namespace PayslipGenerator
{
	public class PayslipTests
	{
		[Fact]
		public void ToString_Returns_PayslipInCSVFormat()
		{
			var payslip = new Payslip("David Rudd", "01 March - 31 March", 5004, 922, 4082, 450);
			var expectedString = "David Rudd,01 March - 31 March,5004,922,4082,450";
			var actualString = payslip.ToString();
			Assert.Equal(expectedString, actualString);
		}
	}
}
