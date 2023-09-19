using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace Assignment2
{
    internal class Program
    {
        public class Employee
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string JobTitle { get; set; }
            public int YearsOfExperience { get; set; }
            public decimal Salary { get; set; }
            public string Department { get; set; }
        }

        public static void Main(string[] args)
        {
            List<Employee> employees;
            using (var reader = new StreamReader("D:/Dotnet/employees.csv")) 
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                employees = csv.GetRecords<Employee>().ToList();
            }
            
            var groupByDepartment = employees.GroupBy(e => e.Department);

            var highestSalaryProjectManager = employees.
                Where(e=>e.JobTitle == "Project Manager")
                .OrderByDescending(e => e.Salary)
                .FirstOrDefault();

            var mostExperiencedWebDeveloper = employees
                .Where(e => e.JobTitle == "Web Developer")
                .OrderByDescending(e => e.YearsOfExperience)
                .FirstOrDefault();

            var averageSalaries = employees
                .GroupBy(e => e.JobTitle)
                .Select(group => new
                {
                    JobTitle = group.Key,
                    AverageSalary = group.Average(e => e.Salary),
                });

            var totalMaleEmployees = employees.Count(e => e.Gender == "male");
            var totalFemaleEmployees = employees.Count(e => e.Gender == "female");


            Console.WriteLine("Employees grouped by their department:");
            foreach(var group in groupByDepartment)
            {
                Console.WriteLine($"Department: {group.Key}\tCount: {group.Count()}");
            }

            Console.WriteLine("\n\nHighest Salary Earning Project Manager:");
            Console.WriteLine($"First Name: {highestSalaryProjectManager.FirstName}" +
                $"\nLast Name: {highestSalaryProjectManager.LastName} " +
                $"\nSalary: {highestSalaryProjectManager.Salary}");

            Console.WriteLine("\n\nMost experienced Web Developer:");
            Console.WriteLine($"First Name: {mostExperiencedWebDeveloper.FirstName}" +
                $"\nLast Name: {mostExperiencedWebDeveloper.LastName} " +
                $"\nYears of Experience: {mostExperiencedWebDeveloper.YearsOfExperience}");

            Console.WriteLine("\n\nAverage Salary of all Job Title:");
            foreach(var avgSalary in averageSalaries)
            {
                Console.WriteLine($"Job Title: {avgSalary.JobTitle}" +
                    $"\tSalary: {avgSalary.AverageSalary}");
            }

            Console.WriteLine($"\n\nTotal Male Employees: {totalMaleEmployees}");
            Console.WriteLine($"\n\nTotal Female Employees: {totalFemaleEmployees}");
        }
    }
}