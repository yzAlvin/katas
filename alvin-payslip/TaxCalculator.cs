using System.IO.Compression;
using System;

namespace kata_payslip
{
    public class TaxCalculator
    {
        public int Threshold;
        public int Principal;
        public double CentsPerDollar;
        public int Tax;

        public int CalculateTax(int salary)
        {
            //repeated code..
            if (salary <= 18200)
            {
                Threshold = 0;
                Principal = 0;
                CentsPerDollar = 0;
            }
            else if (salary <= 37000)
            {
                Threshold = 18200;
                Principal = 0;
                CentsPerDollar = 0.19;
            }
            else if (salary <= 87000)
            {
                Threshold = 37000;
                Principal = 3572;
                CentsPerDollar = 0.325;
            }
            else if (salary <= 180000)
            {
                Threshold = 87000;
                Principal = 19822;
                CentsPerDollar = 0.37;
            }
            else
            {
                Threshold = 180000;
                Principal = 54232;
                CentsPerDollar = 0.45;
            }

            Tax = (int) Math.Round((Principal + (salary - Threshold) * CentsPerDollar) / 12);
            return Tax;
        }
    }
}
