// Student: Emma Jane Heneghan
// Student Number: 10204278

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleAssignment
{
    class ReadWriteFile
    {
        // delcaring the file path
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "DBSDataBase.csv";
        
        // method to Create the file
        public void CreateFile()
        {
            Console.WriteLine("\nA new DBS Person file is now being created in your My Documents folder.\n");
            string content = "Person Type,Name,Phone Number,Email,Status,Student ID,Salary,Subjects Taught";
            File.WriteAllText(filePath, content + Environment.NewLine);
        }

        // method to display menu items
        public void Menu()
        {
            Console.WriteLine("\t\t\t\t\t\t\tDBS Management Software");
            Console.WriteLine("Select from options below:");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Press 0 to QUIT.");
            Console.WriteLine("Press 1 to Add New Student.");
            Console.WriteLine("Press 2 to Add New Teacher.");
            Console.WriteLine("Press 3 to Display Contacts entered in this Session.");
            Console.WriteLine("Press 4 to Display All Contacts in Database.");
            Console.WriteLine("Press 5 to Search Contacts entered in this Session.");
            Console.WriteLine("Press 6 to Search All Contacts in Database.");
            Console.WriteLine("*****************************************************");
        }

        // method to write out student to file
        public void WriteStudentToFile(string name, string phone, string email, string status, string id)
        {
            // streamwriter class is used to write to file
            StreamWriter sw = File.AppendText(filePath);
            // instanciating the student class
            Student stu = new Student(name, phone, email, status, id);
            sw.Write(stu.ToString() + Environment.NewLine);
            sw.Close();
        }

        // method to write out teacher to file
        public void WriteTeacherToFile(string name, string phone, string email, double salary, string subject)
        {
            // streamwriter class is used to write to file
            StreamWriter sw = File.AppendText(filePath);
            // instanciating the student class
            Teacher tea = new Teacher(name, phone, email, salary, subject);
            sw.Write(tea.ToString() + Environment.NewLine);
            sw.Close();
        }
    }
}
