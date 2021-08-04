using System;
using System.Linq;

namespace PayslipGenerator
{
	public static class PayslipMethods
	{
		public static Payslip GeneratePayslip(Data data, TaxBracket[] taxBrackets) =>
			new Payslip(
				$"{data.FirstName} {data.LastName}",
				$"{data.StartDate} - {data.EndDate}",
				GrossIncome(data.AnnualSalary),
				IncomeTax(data.AnnualSalary, taxBrackets),
				NetIncome(data.AnnualSalary, taxBrackets),
				Super(data.AnnualSalary, data.SuperRate)
			);

		private static int GrossIncome(int salary) => salary / 12;

		private static decimal TaxRate(int salary, TaxBracket[] taxBrackets) =>
			taxBrackets.Single(b => salary > b.LowerLimit && salary <= b.UpperLimit).TaxRate;

		private static int FlatTax(int salary, TaxBracket[] taxBrackets) =>
			taxBrackets.Single(b => salary > b.LowerLimit && salary <= b.UpperLimit).FlatTax;

		private static int SubtractionAmount(int salary, TaxBracket[] taxBrackets) =>
			taxBrackets.Single(b => salary > b.LowerLimit && salary <= b.UpperLimit).LowerLimit;

		private static int IncomeTax(int salary, TaxBracket[] taxBrackets) =>
			(int)Math.Ceiling((FlatTax(salary, taxBrackets) + (salary - SubtractionAmount(salary, taxBrackets)) * TaxRate(salary, taxBrackets)) / 12);

		private static int NetIncome(int salary, TaxBracket[] taxBrackets) =>
			GrossIncome(salary) - IncomeTax(salary, taxBrackets);

		private static int Super(int salary, int superRate) =>
			GrossIncome(salary) * superRate / 100;
	}
}
