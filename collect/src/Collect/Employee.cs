using BaseObjects;

namespace Collect
{
    
    public class Employee : NamedObject
    {
        public int DepartmentId { get; set; }
        public Employee(string name)
        {
            Name = name;
        }
    }
}