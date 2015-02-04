// Student: Emma Jane Heneghan
// Student Number: 10204278

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAssignment
{
    class Employee : Person
    {
        // property
        public double Salary { get; set; }

        // constructor
        public Employee(string name, string phone, string email, double salary)
            : base(name, phone, email)
        {
            Salary = salary;
        }
    }
}
