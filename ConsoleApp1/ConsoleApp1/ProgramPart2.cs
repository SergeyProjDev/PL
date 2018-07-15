using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string exit = "e";
            while (true)
            {
                Console.WriteLine("Program started\n");
                Program program = new Program();
                program.StartConsole();


                Console.WriteLine("\nProgram ended. Press `e` to kill or any key to restart.");

                string kod = "";
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Enter)
                    kod += key.KeyChar;
                if (kod.Equals(exit)) break; 
                   else Console.Write("Program restarting...\n");
            }

        }
    }
}
