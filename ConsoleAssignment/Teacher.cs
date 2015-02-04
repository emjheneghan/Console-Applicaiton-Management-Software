// Student: Emma Jane Heneghan
// Student Number: 10204278

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAssignment
{
    class Teacher : Employee
    {
        // properties
        public string SubjectTaught { get; set; }

        // constructor
        public Teacher(string name, string phone, string email, double salary, string subject)
            : base(name, phone, email, salary)
        {
            SubjectTaught = subject;
        }

        // method
        public override string ToString()
        {
            return string.Format("Teacher,{0},{1},{2},{3},{4},{5:00.00},{6}", Name, Phone, Email, "", "", Salary, SubjectTaught);
        }
    }
}
