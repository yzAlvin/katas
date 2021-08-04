using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace PayslipGenerator
{
	class Program
	{
		static void Main(string[] args)
		{
			TaxBracket[] taxBrackets = new TaxBracket[]
			{
				new TaxBracket(0, 18_200, 0.0m, 0),
				new TaxBracket(18_200, 37_000, 0.19m, 0),
				new TaxBracket(37_000, 87_000, 0.325m, 3_572),
				new TaxBracket(87_000, 180_000, 0.37m, 19_822),
				new TaxBracket(180_000, Int32.MaxValue, .45m, 54_232)
			};

			// Don't need to test libraries? idk
			using (var reader = new StreamReader("input.csv"))
			using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
			{
				csv.Context.RegisterClassMap<DataMap>();
				var records = csv.GetRecords<Data>().ToArray();
				var payslips = records.Select(r => PayslipMethods.GeneratePayslip(r, taxBrackets));

				using (var writer = new StreamWriter("output.csv"))
				using (var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
				{
					csvWriter.WriteRecords(payslips);
				}
			}

		}
	}
}
