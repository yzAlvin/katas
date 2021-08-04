namespace PayslipGenerator
{
	public class TaxBracket
	{
		public int LowerLimit { get; }
		public int UpperLimit { get; }
		public decimal TaxRate { get; }
		public int FlatTax { get; }

		public TaxBracket(int lowerLimit, int upperLimit, decimal taxRate, int flatTax)
		{
			LowerLimit = lowerLimit;
			UpperLimit = upperLimit;
			TaxRate = taxRate;
			FlatTax = flatTax;
		}
	}
}