using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    partial class Program
    {
        private void StartConsole()
        {
            Console.WriteLine("Hello!");
            string a = Console.ReadLine();
            Console.WriteLine("New Facking Version, "+a);
        }
    }














    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started\n");
            Program program = new Program();
            program.ExitListener();
            program.StartConsole();


            Console.WriteLine("\nProgram ended");
            Console.ReadKey();
        }
        public void ExitListener()
        {
            
        }
    }
}
