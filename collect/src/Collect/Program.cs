using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Collect
{
    public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
    {
        public bool Equals(Employee x, Employee y)
        {
            return String.Equals(x.Name, y.Name);
        }

        public int GetHashCode(Employee obj)
        {
            return obj.Name.GetHashCode();
        }

        public int Compare(Employee x, Employee y)
        {
            return String.Compare(x.Name, y.Name);
        }
    }

    public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
    {
        public DepartmentCollection Add(string departmentName, Employee employee){
            if (!ContainsKey(departmentName))
            {
                Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
            }
            this[departmentName].Add(employee);
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var departments = new DepartmentCollection();

            departments.Add("Engineering", new Employee("Bob"))
                       .Add("Engineering", new Employee("Scott"))
                       .Add("Engineering", new Employee("Joy"))
                       .Add("Engineering", new Employee("Bob"));

            departments.Add("Sales", new Employee("Alex"))
                       .Add("Sales", new Employee("Sarah"));

            departments.Add("Sales", new Employee("Ryan"));

            foreach (var department in departments)
            {
                 Console.WriteLine(department.Key);
                foreach( var employee in department.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }

            // Console.WriteLine("----LinkedList----");

            // LinkedList<int> list = new LinkedList<int>();
            // list.AddFirst(2);
            // list.AddFirst(3);

            // var first = list.First;
            // list.AddAfter(first, 5);
            // list.AddBefore(first, 10);

            // var node = list.First;
            // while( node != null)
            // {
            //     Console.WriteLine(node.Value);
            //     node = node.Next;
            // }

            // Console.WriteLine("----HashSet----");

            // HashSet<Employee> set = new HashSet<Employee>();
            // var employee1 = new Employee("Scott");
            // set.Add(employee1);
            // set.Add(employee1);

            // foreach(var item in set)
            // {
            //     Console.WriteLine(item.Name);
            // }

            // Console.WriteLine("----Queue----");

            // Queue<Employee> queue = new Queue<Employee>();
            // queue.Enqueue(new Employee("Alex"));
            // queue.Enqueue(new Employee("Dani"));
            // queue.Enqueue(new Employee("Chris"));

            // while (queue.Count > 0)
            // {
            //     var employee = queue.Dequeue();
            //     Console.WriteLine(employee.Name);
            // }

            // Console.WriteLine("----Stack----");
    
            // Stack<Employee> stack = new Stack<Employee>();
            // stack.Push(new Employee("Alex"));
            // stack.Push(new Employee("Dani"));
            // stack.Push(new Employee("Chris"));

            // while (stack.Count > 0)
            // {
            //     var employee2 = stack.Pop();
            //     Console.WriteLine(employee2.Name);
            // }

        }
    }
}
