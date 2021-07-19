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
            Console.WriteLine("\n================== Section (Any) ==================");
            var r = list.Any(Temp => Temp.Id > 3);
            Console.WriteLine("Any User with Id > 3");
            Console.WriteLine("Exist some user with Id > 3: " + r);
            r = list.Any(Temp => Temp.Id > 9);
            Console.WriteLine("Any User with Id > 9");
            Console.WriteLine("Exist some user with Id > 9: " + r);


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n================== Section (All) ==================");
            r = list.All(Temp => Temp.Name != "hello");
            Console.WriteLine("Verify if all users match with the condition (name != \"hello\"): " + r);
            r = list.All(Temp => Temp.Id == 1);
            Console.WriteLine("Verify if all users match with the condition (Id == \"1\"): " + r);


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n================== Section (Contains) ==================");
            Users usr = list.First(Temp => Temp.Id == 1);
            r = list.Contains(usr);
            Console.WriteLine("Return true or false if a specific user it is in the list");
            Console.WriteLine("This user (" + usr + ") is it in the list: " + r);
            usr = new Users(10, "example", Job.Youtuber);
            r = list.Contains(usr);
            Console.WriteLine("This user (" + usr + ") is it in the list: " + r);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n================== Section (Min and Max) ==================");
            var min = list.Min(Temp => Temp.Id);
            Console.WriteLine("Return the min value from the select");
            Console.WriteLine("The min ID found in the list: " + min);
            var max = list.Max(Temp => Temp.Id);
            Console.WriteLine("Return the max value from the select");
            Console.WriteLine("The max ID found in the list: " + max);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n================== Section (Distinct) ==================");
            List<string> distintic = list.Select(Temp => Temp.Name).Distinct().ToList();
            Console.WriteLine("Return The list of Users with Names distinct");
            foreach (var item in distintic)
            {
                Console.WriteLine("The names distints: " + item);
            }
            var distintic2 = list.Select(Temp => Temp.Job).Distinct().ToList();
            Console.WriteLine("\nReturn The list of Users with jobs distinct");
            foreach (var item in distintic2)
            {
                Console.WriteLine("The jobs distints: " + item);
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n================== Section (Take and TakeWhile) ==================");
            list = list.OrderBy(Temp => Temp.Id).ToList();
            var take = list.Take(3);
            Console.WriteLine("Take the quantity of users, if we put list.Take(3) the LINQ will return the first three users.");
            foreach (var item in take)
            {
                Console.WriteLine("User: " + item);
            }
            var takeWhile = list.TakeWhile(Temp => Temp.Id < 3);
            Console.WriteLine("\nThe TakeWhile takes the Users while the condition is \"True\", condition: Temp => Temp.Id < 3: ");
            foreach (var item in takeWhile)
            {
                Console.WriteLine("User: " + item);
            }
            /* ===================================================================== */

            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
