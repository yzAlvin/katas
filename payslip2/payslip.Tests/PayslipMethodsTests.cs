using System;
using Xunit;
using PayslipGenerator;

namespace PayslipGenerator
{
	public class PayslipMethodsTests
	{
		TaxBracket[] taxBrackets = new TaxBracket[]
		{
			new TaxBracket(0, 18_200, 0.0m, 0),
			new TaxBracket(18_200, 37_000, 0.19m, 0),
			new TaxBracket(37_000, 87_000, 0.325m, 3_572),
			new TaxBracket(87_000, 180_000, 0.37m, 19_822),
			new TaxBracket(180_000, Int32.MaxValue, .45m, 54_232)
		};

		[Fact]
		public void GeneratePayslip_ShouldReturn_Payslip()
		{
			// var data = new Data("David", "Rudd", 60050, 9, "01 March", "31 March");
			var data = new Data
			{
				FirstName = "David",
				LastName = "Rudd",
				AnnualSalary = 60050,
				SuperRate = 9,
				StartDate = "01 March",
				EndDate = "31 March"
			};
			var actualPayslip = PayslipMethods.GeneratePayslip(data, taxBrackets);
			var expectedPayslip = new Payslip("David Rudd", "01 March - 31 March", 5004, 922, 4082, 450);
			Assert.Equal(expectedPayslip, actualPayslip);
		}
	}
}
