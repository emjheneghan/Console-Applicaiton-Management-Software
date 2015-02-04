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
    class College
    {
        static void Main(string[] args)
        {
            // editing the Console Window 
            EditStartUp edit = new EditStartUp();
            edit.ConsoleEdit();

            // declaring variables
            int choice = -1;

            // delcaring the file path
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "DBSDataBase.csv";

            // instanciatne the Contacts List class, and Read, Write File Class
            ReadWriteFile rwf = new ReadWriteFile();
            HeavyLifting hl = new HeavyLifting();

            Console.WriteLine("Welcome to Dublin Business School Management Software.\n");

            // create the file, if it does not exist on the system
            if (File.Exists(filePath))
            {
                Console.WriteLine("Loading Current File.\n");
            }
            else
            {
                // create file
                rwf.CreateFile();
                // add test people to CSV and lists - DEMO
                hl.CreateTestPeople();
            }
            
            // do while loop, run the program atleast once
            do
            {
                // method to display menu items
                rwf.Menu();

                // marker to reset when try catch is activated
                TryAgain:
                Console.Write("Enter choice: ");

                // try catch to prevent the program from crashing if user enters letter
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n");
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " You didn't enter a number.");
                    goto TryAgain;
                }

                switch (choice)
                {
                    case 0:
                        // editing the color for when the user exits the program
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You are exiting the program.");
                        // adding a delay to the exit
                        System.Threading.Thread.Sleep(1000);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("All changes have been saved.");
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 1:
                        // call a method to add a new student
                        hl.AddStudent();
                        break;
                    case 2:
                        // call a method to add a new teacher
                        hl.AddTeacher();
                        break;
                    case 3:
                        // call a method to display entries in this session
                        hl.DisplayCurrentSession();
                        break;
                    case 4:
                        // call a method to display all entries in database
                        hl.DisplayCSV();
                        break;
                    case 5:
                        // call a method to search entries in this session
                        hl.SearchThisSession();
                        break;
                    case 6:
                        // call a method to search all entries in database
                        hl.SearchList();
                        break;
                    default:
                        Console.WriteLine("Invalid Seclection");
                        break;
                }
            } while (choice != 0);
        }
    }
}
