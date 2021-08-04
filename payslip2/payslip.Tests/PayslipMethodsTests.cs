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

		[Theory]
		[InlineData(60_050, 5_004)]
		[InlineData(60_070, 5_005)]
		public void GrossIncome_ShouldReturn_SalaryDivide12AndRoundedDown(int salary, int expectedGrossIncome)
		{
			var actualGrossIncome = PayslipMethods.GrossIncome(salary);
			Assert.Equal(expectedGrossIncome, actualGrossIncome);
		}

		[Theory]
		[InlineData(1, 0.0)]
		[InlineData(18_200, 0.0)]
		[InlineData(18_201, 0.19)]
		[InlineData(37_000, 0.19)]
		[InlineData(37_001, 0.325)]
		[InlineData(87_000, 0.325)]
		[InlineData(87_001, 0.37)]
		[InlineData(180_000, 0.37)]
		[InlineData(180_001, 0.45)]
		public void TaxRate_ShouldReturn_ProgressiveTaxRate(int salary, decimal expectedTaxRate)
		{
			var actualTaxRate = PayslipMethods.TaxRate(salary, taxBrackets);
			Assert.Equal(expectedTaxRate, actualTaxRate);
		}

		[Theory]
		[InlineData(1, 0)]
		[InlineData(18_200, 0)]
		[InlineData(18_201, 0)]
		[InlineData(37_000, 0)]
		[InlineData(37_001, 3_572)]
		[InlineData(87_000, 3_572)]
		[InlineData(87_001, 19_822)]
		[InlineData(180_000, 19_822)]
		[InlineData(180_001, 54_232)]
		public void FlatTax_ShouldReturn_FlatTaxAmount(int salary, int expectedFlatTax)
		{
			var actualFlatTax = PayslipMethods.FlatTax(salary, taxBrackets);
			Assert.Equal(expectedFlatTax, actualFlatTax);
		}

		[Theory]
		[InlineData(1, 0)]
		[InlineData(18_200, 0)]
		[InlineData(18_201, 18_200)]
		[InlineData(37_000, 18_200)]
		[InlineData(37_001, 37_000)]
		[InlineData(87_000, 37_000)]
		[InlineData(87_001, 87_000)]
		[InlineData(180_000, 87_000)]
		[InlineData(180_001, 180_000)]
		public void SubtractionAmount_ShouldReturn_SubtractionAmount(int salary, int subtractionAmount)
		{
			var actualSubtractionAmount = PayslipMethods.SubtractionAmount(salary, taxBrackets);
			Assert.Equal(subtractionAmount, actualSubtractionAmount);
		}

		[Theory]
		[InlineData(60_050, 922)]
		public void IncomeTax_ShouldReturn_IncomeTax_RoundedUp(int salary, int expectedIncomeTax)
		{
			var actualIncomeTax = PayslipMethods.IncomeTax(salary, taxBrackets);
			Assert.Equal(expectedIncomeTax, actualIncomeTax);
		}

		[Theory]
		[InlineData(60_050, 4_082)]
		public void NetIncome_ShouldReturn_NetIncome(int salary, int expectedNetIncome)
		{
			var actualNetIncome = PayslipMethods.NetIncome(salary, taxBrackets);
			Assert.Equal(expectedNetIncome, actualNetIncome);
		}

		[Theory]
		[InlineData(60_050, 9, 450)]
		public void Super_ShouldReturn_Super(int salary, int superRate, int expectedSuper)
		{
			var actualSuper = PayslipMethods.Super(salary, superRate);
			Assert.Equal(expectedSuper, actualSuper);
		}

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
