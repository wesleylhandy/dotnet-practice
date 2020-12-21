using System;

namespace  QueryIt
{
    public interface IEntity
    {
        bool IsValid();
    }
    public class Person
    {
        public string Name { get; set;}
    }

    public class Employee : Person, IEntity
    {
        public int Id {get; set;}
        public virtual void DoWork()
        {
            Console.WriteLine("Doing real work");
        }
        public bool IsValid()
        {
            // validation logic here
            return true;
        }
    }

    public class Manager : Employee
    {
        public override void DoWork()
        {
            System.Console.WriteLine("Create a meeting");
        }
    }
}