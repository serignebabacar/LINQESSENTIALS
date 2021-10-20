using Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            // string path = @"C:\Windows";
            //ShowLargeFilesWithoutLinq(path);
            //Console.WriteLine("*********************");
            //ShowLargeFilesWithLinq(path);
           var  developpers = new Employee[]
            {
                new Employee{Id=1,Name="Babacar" },
                 new Employee{Id=2,Name="Abdou" },
                  new Employee{Id=3,Name="Bouba" },
                 new Employee{Id=4,Name="Baba" }
            };
           var sales = new List<Employee>()
            {
                 new Employee {Id = 3,Name = "ALex" }
            };
            var enumerator = sales.GetEnumerator();
            /* while (enumerator.MoveNext())
             {
                 Console.WriteLine(enumerator.Current.Name);
             }*/
            /* foreach (var employee in developpers.Where(e => e.Name.StartsWith("B")))
             {
                 Console.WriteLine(employee.Name);
             }*/

            /*Anonymous method
             * foreach (var employee in developpers.Where(
                delegate (Employee employee)
                {
                    return employee.Name.StartsWith("B");
                 }))
            {
                Console.WriteLine(employee.Name);
            }*/

            /* les Functions et Actions 
             * Func<int, int> f = (x) => ++x;
            Func<int, int, int> f2 = (x, y) => x * y;
            Action<int> Write = w => Console.WriteLine(w);
            Write(f(f2(2, 3)));
            foreach (var employe in developpers.Where(
                e => {
                    return e.Name.StartsWith("B") && e.Name.Length >= 5;
                }).OrderByDescending(f => f.Name))
            {
                Console.WriteLine(employe.Name);
            }*/

            string[] cities = { "Boston", "Los Angeles", "Seattle", "London", "Hyderabad" };
            var query = from city in cities
                                 where city.Length < 15 && city.StartsWith("L")
                                 orderby city
                                 select city;
            var query2 = developpers.Where(e => e.Name.Length >= 5)
                            .OrderBy(e => e.Name)
                            .Select(e => e.Name);
            foreach (var city in query2)
            {
                Console.WriteLine(city);
            }
        }

        /*Named Method
         *  foreach (var employee in developpers.Where(NameStarWithL))
            {
                Console.WriteLine(employee.Name);
            }
         * private static bool NameStarWithL(Employee employee)
        {
            return employee.Name.StartsWith("B");
        }*/

        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(f => f.Length)
                .Take(5);
            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:N0}");
            }
        }
        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo [] files  =  directory.GetFiles();
            Array.Sort(files, new FileInfoComparateur());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name,-20} : {files[i].Length,10:N0}");
            }
        }
    }
    public class FileInfoComparateur : IComparer<FileInfo>
    {
        public int Compare(FileInfo x, FileInfo y)
        {
            return y.Length.CompareTo(x.Length);
        }
    }
}

