using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairProgrammingUsingCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize employeesDB entity
            EmployeesDB employeesDB = new EmployeesDB();

            // If the database is empty, this method will populate it with the 10 default values provided
            employeesDB.SeedDefaultValues();

            // List the employees along with their pay information
            Console.WriteLine("Here is a list of your employees and their pay for this week:\n");

            foreach (var item in employeesDB.EmployeesEntity)
            {
                Console.WriteLine("ID: " + item.ID);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Rate of pay: " + item.RateofPay + " | " + "Hours worked: " + item.HoursWorked);
                Console.WriteLine("Standard pay: " + item.StandardPay.ToString("C") + " | " + "Overtime pay: " + item.OvertimePay.ToString("C"));
                Console.WriteLine("TOTAL PAY: " + item.TotalPay.ToString("C"));
                Console.WriteLine("\n--------------------------------------\n");
            }

            Console.ReadLine();
        }
    }
}
