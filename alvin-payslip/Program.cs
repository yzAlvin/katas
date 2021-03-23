using System;

namespace kata_payslip
{
    class Program
    {
        // How can I automate tests
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the payslip generator!\n");
            Employee employee = new Employee();
            employee.SetDetails();

            Payslip payslip = new Payslip();
            payslip.GeneratePayslip(employee);
            payslip.PrintPayslip();
        }
    }
}
