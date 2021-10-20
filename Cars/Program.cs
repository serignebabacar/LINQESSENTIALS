using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");
            /*foreach (var car in Most10FuelEfficency(cars))
            {
                Console.WriteLine($"{car.Name}: {car.Combined}");
            }*/
            ShowCars(Most10EfficiencyBMW2016(cars));
        }

        private static void ShowCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name}: {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path)
        {
            /* var query2 = File.ReadAllLines(path)
                             .Skip(1)
                             .Where(line => line.Length > 1)
                             .Select(Car.ParseFromCsv)
                             .ToList();*/
            var query = from line in File.ReadAllLines(path).Skip(1)
                         where line.Length > 0
                         select Car.ParseFromCsv(line);
            return query.ToList();
        }
        public static List<Car> Most10FuelEfficency(List<Car> cars)
        {
            var query = cars.OrderByDescending(car => car.Combined)
                            .ThenBy(c => c.Name)
                            .Take(10);
            var query2 = from car in cars
                         orderby car.Combined descending, car.Name ascending
                         select car;
            return query2.Take(10).ToList();
        }
        public static List<Car> Most10EfficiencyBMW2016(List<Car> cars)
        {
            var query1 = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                              .OrderByDescending(c => c.Combined)
                              .ThenBy(c => c.Name);
            var query = from car in cars
                        where car.Manufacturer == "BMW" && car.Year == 2016
                        orderby car.Combined descending, car.Name ascending
                        select car;
            return query.Take(10).ToList();
        }
    }

}
