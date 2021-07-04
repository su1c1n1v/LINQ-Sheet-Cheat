using System;
using System.Collections.Generic;
using System.Linq;

namespace StudingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Users> list = new List<Users>()
            {
                new Users(1,"Vinicius",Job.Developer),
                new Users(2,"Rodrigues",Job.Jornalist),
                new Users(3,"Silva",Job.Developer),
                new Users(4,"Costa",Job.Driver),
                new Users(5,"Vinicius",Job.Youtuber)
            };

            Users[] array = list.ToArray();
            // Default 
            Console.WriteLine("======================= The list =======================");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n===================== Section (Select) =====================");

            var names = list.Select(Temp => Temp.Name);
            Console.WriteLine("\nSelect all Names in the list");
            foreach (var item in names)
            {
                Console.WriteLine("Name: " + item);
            }

            var namesAndJob = list.Select(Temp => new
            {
                Temp.Name,
                Temp.Job
            });

            Console.WriteLine("\nSelect more than one collumn in the list");
            foreach (var item in namesAndJob)
            {
                Console.WriteLine("Name: " + item.Name + ", Job: " + item.Job);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===================== Section (OrderBy) =====================");

            // Ordered by Job
            Console.WriteLine("\nOrdered by Job");
            list = list.OrderBy(Temp => Temp.Job).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nOrdered Descending by Job");
            list = list.OrderByDescending(Temp => Temp.Job).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nOrdered Descending by Job and Ordered by Name");
            list = list.OrderByDescending(Temp => Temp.Job).ThenBy(Temp => Temp.Name).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            //When we have two or more entities with the same "name" the LINQ will order these two or more by the second OrderBy.
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n===================== Section (Where) =====================");
            // Default 
            var newList = list.OrderBy(Temp => Temp.Id).ToList();

            // Search for the id >= 3
            newList = list.Where(Temp => Temp.Id >= 3).ToList();
            Console.WriteLine("\nWhere (Users with Id >= 3)");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            // Search for the id >= 3 and his job is a developer
            newList = list.Where(Temp => Temp.Id >= 3 && Temp.Job == Job.Developer).ToList();
            Console.WriteLine("\nWhere (Users with Id >= 3 and his job is a Developer)");
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n===================== Section (Sum) =====================");

            int idSum = list.Sum(Temp => Temp.Id);
            Console.WriteLine("\nSum of the IDs of the Users: " + idSum);
            // Sum with where
            idSum = list.Where(Temp => Temp.Id >= 3).Sum(Temp => Temp.Id);
            Console.WriteLine("Sum of the IDs of the Users where the ID >= 3: " + idSum);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n================== Section (Average) ==================");

            double idAverage = list.Average(Temp => Temp.Id);
            Console.WriteLine("\nThe average of the IDs: " + idAverage);
            // Average with where
            idAverage = list.Where(Temp => Temp.Id >= 3).Average(Temp => Temp.Id);
            Console.WriteLine("The average of the IDs where the ID >= 3: " + idAverage);


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n================== Section (GroupBy) ==================");
            var l = list.OrderBy(Temp => Temp.Job).GroupBy(Temp => Temp.Job);
            Console.WriteLine("Group by Job");
            foreach (var item in l)
            {
                Console.WriteLine("Group: " + item.Key + ", Quantity: " + item.Select(x => x.Name).Count());
                foreach (var item2 in item)
                {
                    Console.WriteLine(" - " +item2);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
