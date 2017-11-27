using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            DateTime providedDate = new  DateTime(year, month, day);
            DateTime previousDate = providedDate.AddDays(-1);
            Console.WriteLine("{0:d-MMM-yyyy}", previousDate);

        }
    }
}
