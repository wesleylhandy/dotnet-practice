using System;
using System.Collections.Generic;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
            Console.WriteLine(employeeList.GetType().Name);
            Console.WriteLine(employeeList.GetType().FullName);
            var genericArguments = employeeList.GetType().GenericTypeArguments;
            foreach (var arg in genericArguments)
            {
                Console.WriteLine("[{0}]", arg.Name);
            }
            Console.WriteLine();
            var employee = new Employee();
            var employeeType = typeof(Employee);
            var methodInfo = employeeType.GetMethod("Speak");
            methodInfo = methodInfo.MakeGenericMethod(typeof(DateTime));
            methodInfo.Invoke(employee, null);
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }


    }
    public class Employee
    {
        public string Name { get; set; }
        public void Speak<T>()
        {
            Console.WriteLine(typeof(T).Name);
        }
    }
}
