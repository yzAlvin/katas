namespace PayslipGenerator
{
	public class Payslip
	{
		public Payslip(string name, string payPeriod, int grossIncome, int incomeTax, int netIncome, int super)
		{
			Name = name;
			PayPeriod = payPeriod;
			GrossIncome = grossIncome;
			IncomeTax = incomeTax;
			NetIncome = netIncome;
			Super = super;
		}

		public string Name { get; }
		public string PayPeriod { get; }
		public int GrossIncome { get; }
		public int IncomeTax { get; }
		public int NetIncome { get; }
		public int Super { get; }

		public override bool Equals(object obj)
		{
			var otherPayslip = obj as Payslip;
			return this.Name == otherPayslip.Name
			&& this.PayPeriod == otherPayslip.PayPeriod
			&& this.GrossIncome == otherPayslip.GrossIncome
			&& this.IncomeTax == otherPayslip.IncomeTax
			&& this.NetIncome == otherPayslip.NetIncome
			&& this.Super == otherPayslip.Super;
		}

		public override string ToString() =>
			$"{this.Name},{this.PayPeriod},{this.GrossIncome},{this.IncomeTax},{this.NetIncome},{this.Super}";
	}
}