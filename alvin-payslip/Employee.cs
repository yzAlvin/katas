using System.ComponentModel;
using System;

namespace kata_payslip
{
    public class Employee
    {
        public string Name;
        public string Surname;
        public int Salary;
        public int SuperRate;
        public DateTime PaymentStartDate;
        public DateTime PaymentEndDate;

        public void SetDetails()
        {
            //Set Employee information
            Console.Write("Please input your name: ");
            Name = Console.ReadLine();

            Console.Write("Please input your surname: ");
            Surname = Console.ReadLine();

            Console.Write("Please input your annual salary: ");
            Salary = GetSalary();

            Console.Write("Please input your super rate: ");
            SuperRate = GetSuper();

            Console.Write("Please input your payment start date: ");
            PaymentStartDate = GetDate();

            Console.Write("Please input your payment end date: ");
            PaymentEndDate = GetDate();
        }

        private int GetSalary()
        {
            int num;
            bool parseCheck = Int32.TryParse(Console.ReadLine(), out num);
            while (!parseCheck | num < 0)
            {
                Console.WriteLine("Please enter a a positive integer");
                parseCheck = Int32.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }

        private int GetSuper()
        {
            int num;
            bool parseCheck = Int32.TryParse(Console.ReadLine(), out num);
            while (!parseCheck | (num < 0 | num > 50))
            {
                Console.WriteLine("Please enter a valid super rate (0 to 50 inclusive).");
                parseCheck = Int32.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }

        private DateTime GetDate()
        {
            DateTime date;
            bool parseCheck = DateTime.TryParse(Console.ReadLine(), out date);
            while (!parseCheck)
            {
                Console.WriteLine("Please enter a valid date");
                parseCheck = DateTime.TryParse(Console.ReadLine(), out date);
            }
            return date;
        }
    }
}
