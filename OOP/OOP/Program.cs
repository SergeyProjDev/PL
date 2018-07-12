using System;
using System.Collections.Generic;
using System.Text;

using OOP1;
namespace OOP
{
    partial class Program : OOP2
    {
        private void StartConsole()
        {
            SaYHelloSergey();
        }
    }
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started");
            Program program = new Program();
            program.StartConsole();

            Console.WriteLine("Program ended");
            Console.ReadKey();
        }
    }
}

namespace OOP1
{
    class OOP2
    {
        public void SaYHelloSergey()
        {
            Console.WriteLine("Hello Sergey!");
        }
    }
}
