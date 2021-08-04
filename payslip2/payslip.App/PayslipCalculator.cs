using System;
using System.Linq;

namespace PayslipGenerator
{
	public static class PayslipMethods
	{
		public static int GrossIncome(int salary) => salary / 12;

		public static decimal TaxRate(int salary, TaxBracket[] taxBrackets) =>
			taxBrackets.Single(b => salary > b.LowerLimit && salary <= b.UpperLimit).TaxRate;

		public static int FlatTax(int salary, TaxBracket[] taxBrackets) =>
			taxBrackets.Single(b => salary > b.LowerLimit && salary <= b.UpperLimit).FlatTax;

		public static int SubtractionAmount(int salary, TaxBracket[] taxBrackets) =>
			taxBrackets.Single(b => salary > b.LowerLimit && salary <= b.UpperLimit).LowerLimit;

		public static int IncomeTax(int salary, TaxBracket[] taxBrackets) =>
			(int)Math.Ceiling((FlatTax(salary, taxBrackets) + (salary - SubtractionAmount(salary, taxBrackets)) * TaxRate(salary, taxBrackets)) / 12);

		public static int NetIncome(int salary, TaxBracket[] taxBrackets) =>
			GrossIncome(salary) - IncomeTax(salary, taxBrackets);

		public static int Super(int salary, int superRate) =>
			GrossIncome(salary) * superRate / 100;

		public static Payslip GeneratePayslip(Data data, TaxBracket[] taxBrackets) =>
			new Payslip(
				$"{data.FirstName} {data.LastName}",
				$"{data.StartDate} - {data.EndDate}",
				GrossIncome(data.AnnualSalary),
				IncomeTax(data.AnnualSalary, taxBrackets),
				NetIncome(data.AnnualSalary, taxBrackets),
				Super(data.AnnualSalary, data.SuperRate)
			);
	}
}
