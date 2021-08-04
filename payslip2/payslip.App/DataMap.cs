using CsvHelper.Configuration;

namespace PayslipGenerator
{
	public sealed class DataMap : ClassMap<Data>
	{
		public DataMap()
		{
			Map(m => m.FirstName).Name("first name", "FirstName");
			Map(m => m.LastName).Name("last name", "LastName");
			Map(m => m.AnnualSalary).Name("annual salary", "AnnualSalary");
			Map(m => m.SuperRate).Name("super rate (%)", "SuperRate");
			Map(m => m.StartDate).Name("payment start date", "StartDate");
			Map(m => m.EndDate).Name("payment end date", "EndDate");
		}
	}

}