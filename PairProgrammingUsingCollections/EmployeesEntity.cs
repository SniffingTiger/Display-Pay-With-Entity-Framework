namespace PairProgrammingUsingCollections
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel;

    public class EmployeesDB : DbContext
    {
        // Your context has been configured to use a 'Employees' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'PairProgrammingUsingCollections.Employees' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Employees' 
        // connection string in the application configuration file.
        public EmployeesDB()
            : base("name=Employees") { }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Employee> EmployeesEntity { get; set; }

        // If the database is empty, this method will seeds the database with default values
        public void SeedDefaultValues()
        {
            if (this.EmployeesEntity.Count() == 0)
            {
                var JohnLandry = new Employee(15.00, 35.50)
                {   ID = 223445,
                    Name = "John Landry" };

                var AngelaRush = new Employee(15.00, 32.25)
                {   ID = 223476,
                    Name = "Angela Rush" };

                var BillMarsh = new Employee(16.50, 45.50)
                {   ID = 223487,
                    Name = "Bill Marsh" };

                var PeggySimon = new Employee(16.75, 50)
                {   ID = 223504,
                    Name = "Peggy Simon" };

                var CarlYost = new Employee(15.75, 40)
                {   ID = 223519,
                    Name = "Carl Yost" };

                var JoeMiles = new Employee(15.00, 40)
                {   ID = 223519,
                    Name = "Joe Miles" };

                var JoanJeffries = new Employee(14.25, 25.75)
                {   ID = 223525,
                    Name = "Joan Jeffries" };

                var GeorgeMills = new Employee(13.65, 38)
                {   ID = 223536,
                    Name = "George Mills" };

                var GaryCooper = new Employee(15.25, 37.25)
                {   ID = 223542,
                    Name = "Gary Cooper" };

                var MaryMillicent = new Employee(15.75, 40)
                {   ID = 223558,
                    Name = "Mary Millicent" };

                this.EmployeesEntity.Add(JohnLandry);
                this.EmployeesEntity.Add(AngelaRush);
                this.EmployeesEntity.Add(BillMarsh);
                this.EmployeesEntity.Add(PeggySimon);
                this.EmployeesEntity.Add(CarlYost);
                this.EmployeesEntity.Add(JoeMiles);
                this.EmployeesEntity.Add(JoanJeffries);
                this.EmployeesEntity.Add(GeorgeMills);
                this.EmployeesEntity.Add(GaryCooper);
                this.EmployeesEntity.Add(MaryMillicent);
                this.SaveChanges();
            }
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double RateofPay { get; set; }
        public double HoursWorked { get; set; }
        public double StandardPay { get; set; }
        public double OvertimePay { get; set; }
        public double TotalPay { get; set; }

        // Default constructor
        public Employee() {}

        // This constructor will automatically set the correct values for StandardPay, OvertimePay, and TotalPay using the
        // rateOfPay and HoursWorked parameters, which will also provide values for their respective properties.
        public Employee(double rateOfPay, double hoursWorked)
        {
            OvertimePay = 0;
            RateofPay = rateOfPay;
            HoursWorked = hoursWorked;
            // If the employee worked over 40 hours, calculate overtime and standard pay
            if (HoursWorked > 40)
            {
                StandardPay = RateofPay * 40;
                OvertimePay = RateofPay * (HoursWorked - 40);
            }
            // If the employee worked 40 hours or less, calculate standard pay
            else
            {
                StandardPay = RateofPay * HoursWorked;
            }
            // Set the TotalPay property to the sum of StandardPay and OvertimePay
            TotalPay = StandardPay + OvertimePay;
        }
    }
}