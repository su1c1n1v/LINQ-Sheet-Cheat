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

            Console.WriteLine("===================== Section (OrderBy) =====================");
            // Default 
            Console.WriteLine("Default");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

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

            Console.WriteLine("\n===================== Section (Where) =====================");
            // Default 
            var newList = list.OrderBy(Temp => Temp.Id).ToList();
            Console.WriteLine("Default");
            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }

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
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n===================== Section (Sum) =====================");
            // Default 
            newList = list.OrderBy(Temp => Temp.Id).ToList();
            Console.WriteLine("Default");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            int idSum = list.Sum(Temp => Temp.Id);
            Console.WriteLine("\nSum of the IDs of the Users: " + idSum);
            // Sum with where
            idSum = list.Where(Temp => Temp.Id >= 3).Sum(Temp => Temp.Id);
            Console.WriteLine("\nSum of the IDs of the Users where the ID >= 3: " + idSum);
        }
    }
}
