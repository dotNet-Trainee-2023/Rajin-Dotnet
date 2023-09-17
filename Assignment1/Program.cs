using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class Program
    {
        //Class abstraction and encaplusation
        public abstract class Animal
        {
            public string name;
            public int age;

            public Animal(string name, int age) 
            { 
                this.name = name;
                this.age = age;
            }
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public int Age
            {
                get { return age; }
                set { age = value; }
            }
            public abstract void MakeSound();
            public void Display() 
            {
                Console.WriteLine($"Name : {Name} \t Age : {Age}");
            }
        }
        public class Dog : Animal
        {
            public Dog(string name, int age):base(name, age) { }
            public override void MakeSound()
            {
                Console.WriteLine("Dog barks.");
            }
        }
        public class Lion : Animal
        {
            public Lion(string name, int age):base (name, age) { }
            public override void MakeSound()
            {
                Console.WriteLine("Lion roars.");
            }
        }

        //Parsing with multiple inheritance and tuples
        public interface IIntParse
        {
            (int,int) IntParse(string value);
        }
        public interface IBoolParse
        {
            (bool, bool) BoolParse(string value);
        }
        public class Parsing : IIntParse, IBoolParse
        {
            public (int,int) IntParse(string value)
            {
                int result1,result2;
                
                int.TryParse(value, out result1);
                result2 = int.Parse(value);
                return (result1,result2);
            }

            public (bool, bool) BoolParse(string value)
            {
                bool result1, result2;

                bool.TryParse(value, out result1);
                result2 = bool.Parse(value);
                return (result1,result2);
            }
        }

        //Use case of ternary operator and Null Colascing operator.
        public class Employee
        {
            public int? EmployeeId { get; set; }
            public string? Name { get; set; }
            public string? Address { get; set; }

           /* public Employee(int? employeeId, string? name, string? address)
            {
                EmployeeId = employeeId;
                Name = name;
                Address = address;
            }*/

            public void DisplayInfo()
            {
                Console.WriteLine($"Employee id: {EmployeeId ?? 100}\t Name: {Name ?? "user"}\t Address: {Address ?? "unknown"}" );
            }
        }

        public static void Main(string[] args)
        {
            // Abstraction, Polymorphism and Encapsulation
            Animal dog = new Dog("Tommy", 5);
            Animal lion = new Lion("Lion", 7);

            Console.WriteLine("Abstraction, Polymorphism and Encapsulation");

            dog.MakeSound();
            dog.Display();

            Console.WriteLine();

            lion.MakeSound();
            lion.Display();

            ////////////////////////
            //Parsing with multiple inheritance.            
            Parsing p = new Parsing();

            Console.WriteLine("\n\nParsing with multiple inheritance.");

            Console.WriteLine("Parsed int " + p.IntParse("12345"));
            Console.WriteLine("Parsed bool " + p.BoolParse("True"));

            ///////////////////////
            //Use case of ternary operator and Null Colascing operator.
            Console.WriteLine("\n\nUse case of ternary operator and Null Colascing operator.");
            //Shows default value if value not assigned.
            Employee e1 = new Employee();
            Console.WriteLine("\n\nWithout assigning values");
            e1.DisplayInfo();

            Employee e2 = new Employee();
            e2.EmployeeId = 1;
            e2.Name = "Rajin";
            e2.Address = "Kathmandu";
            Console.WriteLine("\nAfter assigning values");
            e2.DisplayInfo();

            /////////////////////////////
            //LINQ operations
            Console.WriteLine("\n\nLINQ operations");
            List<int> l1 = new List<int> {5,7,9,2,3,6,7,11,23,4,55,61,32,12,56,11 };

            double l1Avg = l1.Average();
            Console.WriteLine($"Average of list l1 is {l1Avg}");
            l1.Sort();
            Console.WriteLine("\nSorted List l1 in ascending:");
            foreach(var i in l1)
            {
                Console.WriteLine(i);
            }
            IEnumerable<int> l1Sort =  l1.OrderByDescending(x => x);
            Console.WriteLine("\nSorted List l1 in descending:");
            foreach(var i in l1Sort)
            {
                Console.WriteLine(i);
            }

            IEnumerable<int> greaterThanFive = l1.FindAll(x=> x > 5 && x < 20);
            Console.WriteLine("\nNumbers in list l1 greater than 5 and less than 20");
            foreach(var i in greaterThanFive)
            {
                Console.WriteLine(i);
            }

            List<string> l2 = new List<string> { "Australia", "Germany", "Denmark", "Nepal", "Malaysia", "New Zealand", "Nigeria" };

            IEnumerable<string> countriesStartingWithN = l2.Where(x => x.StartsWith("N"));

            Console.WriteLine("\nCountries starting with alphabet N");
            foreach(var i in countriesStartingWithN)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\nCountries starting with alphabet N and ends with A");
            IEnumerable<string> endingWithA = l2.Where(x => x.StartsWith("N") && x.EndsWith("A"));




        }
    }
}
