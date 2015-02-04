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
    class HeavyLifting
    {
        // delcaring the file path
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "DBSDataBase.csv";

        // instancating the teacher and student lists
        List<Student> stu = new List<Student>();
        List<Teacher> tea = new List<Teacher>();

        // instancating the ReadWriteFile Class
        ReadWriteFile rwf = new ReadWriteFile();

        // declaring private variables
        private string name, email, phone, id, status, subjects;
        private double salary;

        // the DEMO test code
        public void CreateTestPeople()
        {
            // streamwriter class is used to write out to CSV file
            StreamWriter sw = File.AppendText(filePath);
            sw.WriteLine("Teacher,EMMA SMITH,0878956231,emma.smith@dbs.ie,,,30000,Political Science");
            sw.WriteLine("Student,TOM JONES,0861234123,tom.jone@dbs.ie,POSTGRAD,12345678");
            sw.WriteLine("Teacher,TOM JONES,0861234123,tom.jone@dbs.ie,,,30000,Computer Science");
            sw.WriteLine("Student,EMMA SMITH,0854567895,emma.smith@gmail.ie,UNDERGRAD,78945632");
            sw.Close();

            // instancating the student class
            Student testS1 = new Student("TOM JONES", "0861234123", "tom.jones@dbs.ie", "POSTGRAD", "12345678");
            Student testS2 = new Student("EMMA SMITH", "0854567895", "emma.smith@gmail.ie", "UNDERGRAD", "78945632");

            // add student to the student list
            stu.Add(testS1);
            stu.Add(testS2);

            // instancating the Teacher Class
            Teacher testT1 = new Teacher("TOM JONES", "0861234123", "tom.jones@dbs.ie", 30000, "Computer Science");
            Teacher testT2 = new Teacher("EMMA SMITH", "0878956231", "emma.smith@dbs.ie", 30000, "Political Science");

            // add Teacher to the teacher class
            tea.Add(testT1);
            tea.Add(testT2);
        }

        // method to add person name, phone, email
        public void AddPerson()
        {
            // name set ToUpper for searching purposes
            Console.Write("Please enter Name: ");
            name = Console.ReadLine().ToUpper();
            Console.Write("Please enter Phone Number: ");
            phone = Console.ReadLine();
            Console.Write("Please enter email: ");
            email = Console.ReadLine();
        }

        // method to add Student
        public void AddStudent()
        {
            // variable for error detection
            int check = 1;

            AddPerson();

            while (check == 1)
            {
                Console.Write("Please enter the Student Status (Postgrad or Undergrad): ");
                status = Console.ReadLine().ToUpper();
                if (status == "POSTGRAD" || status == "UNDERGRAD")
                    check = 0;
                else if (status != "Postgrad" || status != "Undergrad")
                    Console.WriteLine("You have entered an incorrect Status. Please try again.");
            }
            Console.Write("Please enter the Student ID: ");
            id = Console.ReadLine();

            // instancating the student class
            Student newS = new Student(name, phone, email, status, id);

            // add student to the student list
            stu.Add(newS); 

            // write out the student information to the file
            rwf.WriteStudentToFile(name, phone, email, status, id);

            // return to main menu, clear screen
            Console.WriteLine("The Student Contact has been added to the CSV file.");
            ReturnToMenu();
        }

        // method to add Teacher
        public void AddTeacher()
        {
            AddPerson();

            Console.Write("Please enter the Teachers Salary: ");
            salary = double.Parse(Console.ReadLine());
            Console.Write("Please enter the Subjects Taught: ");
            subjects = Console.ReadLine();

            // instancating the Teacher Class
            Teacher newT = new Teacher(name, phone, email, salary, subjects);

            // add Teacher to the teacher class
            tea.Add(newT);

            // write out the teacher information to the file
            rwf.WriteTeacherToFile(name, phone, email, salary, subjects);

            // return to main menu, clear screen
            Console.WriteLine("The Teacher Contact has been added to the CSV file.");
            ReturnToMenu();
        }
        
        // method to display both Student and Teacher lists
        public void DisplayCurrentSession()
        {
            Console.WriteLine("Displaying Contacts Entered in this Session.");
            // if statement to check if the student list is empty
            if (stu.Count == 0)
            {
                Console.WriteLine("The Student list is empty.");
            }
            // else want to loop through and shows whats in it
            else
            {
                // write out column titles
                ColumnTitles();

                foreach (Student s in stu)
                {
                    Console.Write("Student\t\t|{0}\t|{1}\t|{2}\t|{3}\t|{4}\t\t|\t\t|", s.Name, s.Phone, s.Email, s.Status, s.StudentID);
                    Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
                }
            }

            // if statement to check if the teacher list is empty
            if (tea.Count == 0)
            {
                Console.WriteLine("The Teacher list is empty.");
            }
            // else want to loop through and shows whats in it
            else
            {
                // write out column titles
                ColumnTitles();

                foreach (Teacher t in tea)
                {
                    Console.Write("Teacher\t\t|{0}\t|{1}\t|{2}\t|\t\t|\t\t\t|{3}\t\t|{4}",t.Name, t.Phone, t.Email, t.Salary, t.SubjectTaught);
                    Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
                }
            }

            // return to main menu, clear screen
            ReturnToMenu();
        }

        // method to display from csv file
        public void DisplayCSV()
        {
            Console.WriteLine("Displaying All Contacts in Database.");
            // streamreader class constructed with the filePath in it
            StreamReader sr = new StreamReader(filePath);

            // Open the file to read from
            string[] readText = File.ReadAllLines(filePath);

            // create a two dimensional array to hold all the information
            int numRows = readText.Length;
            int numColumns = 8;
            string[,] csvData = new string[numRows, numColumns];

            // populating the 2d array csvData
            for (int i = 0; i < numRows; i++)
            {
                string[] newArray = readText[i].Split(',');
                int j = 0;
                foreach (string n in newArray)
                {
                    csvData[i, j] = n;
                    j++;
                }
            }

            // write out column titles
            ColumnTitles();

            for (int i = 1; i < numRows; i++)
            {
                for (int j = 0; j < numColumns; j++)
                {
                    // write out when student entry
                    if (csvData[i, 0] == "Student")
                    {
                        // use method to write out student information
                        WriteOutStudentCSV(csvData, i, j);
                    }
                    // write out when teacher entry
                    if (csvData[i, 0] == "Teacher")
                    {
                        // use method to write out teacher information
                        WriteOutTeacherCSV(csvData, i, j);
                    }
                }
                Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
            }
            
            // close streamreader
            sr.Close();

            // return to main menu, clear screen
            ReturnToMenu();
        }

        // method to search within the current session
        public void SearchThisSession()
        {
            // declaring variables
            bool foundMatch = false;
            int duplicate = 0;

            Console.WriteLine("\nEnter Name to Search:");
            name = Console.ReadLine().ToUpper();

            Console.WriteLine("\nSearching Entries");
            Console.WriteLine("****************************\n");

            // foreach loop to search within the Student List
            foreach (Student s1 in stu)
            {
                if (s1.Name == name)
                {
                    ColumnTitles();
                    Console.Write("Student\t\t|{0}\t|{1}\t|{2}\t|{3}\t|{4}\t\t|\t\t|", s1.Name, s1.Phone, s1.Email, s1.Status, s1.StudentID);
                    Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
                    foundMatch = true;
                    duplicate = 1;

                    // foreach loop to search within the Teacher List, if a copy is found in the Student List
                    foreach (Teacher t1 in tea)
                    {
                        if (t1.Name == name)
                        {
                            ColumnTitles();
                            Console.Write("Teacher\t\t|{0}\t|{1}\t|{2}\t|\t\t|\t\t\t|{3}\t\t|{4}", t1.Name, t1.Phone, t1.Email, t1.Salary, t1.SubjectTaught);
                            Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
                            foundMatch = true;
                        }
                        // if statement to check if these are the same person
                        if (s1.Phone == t1.Phone)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n\t\tAlert!\n\tThis is the same Person.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }

            // if statement to search through teachers for match, if there is no match for student
            if (duplicate == 0)
            {
                foreach (Teacher t1 in tea)
                {
                    if (t1.Name == name)
                    {
                        ColumnTitles();
                        Console.Write("Teacher\t\t|{0}\t|{1}\t|{2}\t|\t\t|\t\t\t|{3}\t\t|{4}", t1.Name, t1.Phone, t1.Email, t1.Salary, t1.SubjectTaught);
                        Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
                        foundMatch = true;
                    }
                }
            }

            // if statement id no matches are found
            if (!foundMatch)
            {
                Console.WriteLine("No Matches Found.");
            }

            // return to main menu, clear screen
            ReturnToMenu();
        }

        // method to search entire database
        public void SearchList()
        {
            // streamreader class being constructed with the filePath in it
            StreamReader sr = new StreamReader(filePath);

            // Open the file to read from
            string[] readText = File.ReadAllLines(filePath);

            // create a two dimensional array to hold all the information
            int numRows = readText.Length;
            int numColumns = 8;
            string[,] csvData = new string[numRows, numColumns];

            // populating the 2d array with data from csvData
            for (int i = 0; i < numRows; i++)
            {
                string[] newArray = readText[i].Split(',');
                int j = 0;
                foreach (string n in newArray)
                {
                    csvData[i, j] = n;
                    j++;
                }
            }

            bool foundMatch = false;
            string name;
            int count = 0, compare1 = 0, compare2 = 0;

            Console.WriteLine("\nEnter Name to Search in Database:");
            name = Console.ReadLine().ToUpper();

            Console.WriteLine("\nSearching Contacts");
            Console.WriteLine("****************************\n");

            // search through array, starting on first person not column titles
            for (int x = 1; x < numRows; x++)
            {
                // initalising y as 1 to search only the name column
                int y = 1;
                if (csvData[x, y] == name)
                {
                    Console.WriteLine("\nMatch found:");
                    foundMatch = true;
                    count++;
                    int i = 0;

                    // write out column titles
                    ColumnTitles();
                    
                    // write out searched entry if found
                    i = x;
                    for (int j = 0; j < numColumns; j++)
                    {
                        // write out when student entry
                        if (csvData[i, 0] == "Student")
                        {
                            // use method to write out to screen student information
                            WriteOutStudentCSV(csvData, i, j);
                            compare1 = i;
                        }
                        // write out when teacher entry
                        if (csvData[i, 0] == "Teacher")
                        {
                            // use method to write out to screen teacher information
                            WriteOutTeacherCSV(csvData, i, j);
                            compare2 = i;
                        }
                    }
                    Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
                }
            }

            // compare if this is the same person
            if (csvData[compare1, 2] == csvData[compare2, 2])
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t\tAlert!\n\tThis is the same person.");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (!foundMatch)
            {
                Console.WriteLine("No Matches Found.");
            }

            // close streamreader
            sr.Close();

            // return to main menu, clear screen
            ReturnToMenu();
        }

        // method to write out column titles
        public void ColumnTitles()
        {
            Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
            Console.Write("|Person Type\t|Name\t\t|Phone Number\t|Email\t\t\t|Status\t\t|Student ID\t\t|Salary\t\t|Subjects Taught");
            Console.Write("\n--------------------------------------------------------------------------------------------------------------------------------------------\n");
        }

        // method to write out student information from CSV
        public void WriteOutStudentCSV(string[,] n, int i, int j)
        {
            if (i > 0 && (j == 0 || j == 1 || j == 2 || j == 3 || j == 4 || j == 5))
            {
                Console.Write("|{0}\t", n[i, j]);
            }
            if (i > 0 && j == 6)
            {
                Console.Write("|{0}\t\t", n[i, j]);
            }
            if (i > 0 && j == 7)
            {
                Console.Write("|{0}\t", n[i, j]);
            }
        }

        // method to write out teacher information from CSV
        public void WriteOutTeacherCSV(string[,] n, int i, int j)
        {
            if (i > 0 && (j == 0 || j == 1 || j == 2 || j == 3))
            {
                Console.Write("|{0}\t", n[i, j]);
            }
            if (i > 0 && j == 4 || j == 5)
            {
                Console.Write("|{0}\t\t", n[i, j]);
            }
            if (i > 0 && j == 6)
            {
                Console.Write("|{0:00.00}\t\t", n[i, j]);
            }
            if (i > 0 && j == 7)
            {
                Console.Write("|{0}\t", n[i, j]);
            }
        }

        public void ReturnToMenu()
        {
            Console.WriteLine("\nPress any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
