﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using Features.Linq;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Action<int> write = x => Console.WriteLine(x);

            write(square(add(3, 5)));

            var developers = new Employee[]
            {
                new Employee { Id = 1, Name="Wes" },
                new Employee { Id = 2, Name="Nate" }
            };

            var sales = new List<Employee>()
            {
                new Employee { Id = 3, Name="Stephen" }
            };

            // foreach( var employee in developers.Where(NameStartsWithS) )
            // {
            //     System.Console.WriteLine(employee.Name);
            // }

            // foreach( var employee in developers.Where( delegate (Employee employee)
            //     {
            //         return employee.Name.StartsWith("S");
            //     }))
            // {
            //     System.Console.WriteLine(employee.Name);
            // }

            var query = developers.Where(e => e.Name.Length == 3).OrderBy(e=> e.Name);

            var query2 = from developer in developers
                        where developer.Name.Length == 3
                        orderby developer.Name
                        select developer;

            foreach( var employee in query2 )
            {
                System.Console.WriteLine(employee.Name);
            }
        }

        private static bool NameStartsWithS(Employee employee)
        {
            return employee.Name.StartsWith("S");
        }
    }
}