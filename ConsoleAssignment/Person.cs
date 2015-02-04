// Student: Emma Jane Heneghan
// Student Number: 10204278

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAssignment
{
    class Person
    {
        // properties - name, phone and email
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // constructor
        public Person(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;
        }

        // methods
        public override string ToString()
        {
            return string.Format(Name + "," + Phone + "," + Email);
        }

        // Overload the equality operator (==)
        public static bool operator ==(Person p1, Person p2)
        {
            // want to check is one name the same as the other
            if (p1.Name == p2.Name)
            {
                // if they are the same return true
                return true;
            }
            else
            {
                return false;
            }
        }

        // overload the not equals to operator
        public static bool operator !=(Person p1, Person p2)
        {
            return !(p1 == p2);
        }
    }
}
