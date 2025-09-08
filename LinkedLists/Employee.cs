using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class Employee : IComparable<Employee>
    {
        public int EmployeeID { get; set; }
        public string? FirstName { get; }
        public string?  LastName { get; }

        public Employee(int employeeID)
        {
            EmployeeID = employeeID;
        }

        public Employee(int employeeID, string firstName, string lastName)
        {
            EmployeeID = employeeID;
            FirstName = firstName;
            LastName = lastName;
        }

        int IComparable<Employee>.CompareTo(Employee? other)
        {
            return this.EmployeeID.CompareTo(other?.EmployeeID);
        }

        public override string ToString()
        {
            if(FirstName == null && LastName == null)
            {
                return $"{EmployeeID} null null";
            }
            else
            {
                return $"{EmployeeID} {FirstName} {LastName}";
            }
        }
    }
}