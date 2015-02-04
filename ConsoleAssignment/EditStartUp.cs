// Student: Emma Jane Heneghan
// Student Number: 10204278

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAssignment
{
    class EditStartUp
    {
        // method to edit console appearance
        public void ConsoleEdit()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(Console.LargestWindowWidth-20, Console.LargestWindowHeight-20);
            Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop);
        }
    }
}
