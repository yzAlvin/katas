using System;

namespace kata_payslip
{
    public class Payslip
    {
        public string Name;
        public string PayPeriod;
        public int GrossIncome;
        public int IncomeTax;
        public int NetIncome;
        public int Super;

        public void GeneratePayslip(Employee employee)
        {
            // should these be methods so I can test them individually?
            Name = employee.Name + " " + employee.Surname;
            
            PayPeriod = employee.PaymentStartDate.ToString("dd MMMM") + " - " + employee.PaymentEndDate.ToString("dd MMMM");;
            
            GrossIncome = (int)Math.Round(employee.Salary / 12M, MidpointRounding.ToEven);
            
            TaxCalculator taxCalculator = new TaxCalculator();
            IncomeTax = taxCalculator.CalculateTax(employee.Salary);

            NetIncome = GrossIncome - IncomeTax;
            Super = (int)Math.Round(GrossIncome * (employee.SuperRate/100M), MidpointRounding.ToEven);
        }

        public void PrintPayslip()
        {
            Console.WriteLine("\nYour payslip has been generated:\n ");
            
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Pay Period: {PayPeriod}");
            Console.WriteLine($"Gross Income: {GrossIncome}");
            Console.WriteLine($"Income Tax: {IncomeTax}");
            Console.WriteLine($"Net Income: {NetIncome}");
            Console.WriteLine($"Super: {Super}");

            Console.WriteLine("\nThank you for using MYOB!");
        }

    }
}
