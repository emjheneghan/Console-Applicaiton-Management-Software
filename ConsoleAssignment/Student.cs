// Student: Emma Jane Heneghan
// Student Number: 10204278

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAssignment
{
    class Student : Person
    {
        // properties 
        public string Status { get; set; }
        public string StudentID { get; set; }

        // constructors
        public Student(string name, string phone, string email, string status, string id)
            : base(name, phone, email)
        {
            Status = status;
            StudentID = id;
        }

        // method
        public override string ToString()
        {
            return string.Format("Student,{0},{1},{2},{3},{4}", Name, Phone, Email, Status, StudentID);
        }
    }
}
