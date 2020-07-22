using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Channels;

namespace CarCompareConsole
{
    class Program
    {
        
        /*this console is meant to work break open and show what is in the Vehicles
        *given the code exercise instructions, I wasn't sure if the Library should return 
        *a List of the "object" or just a string that gave a make and model, proving that the object existed.
        *so while the library creates the object and returns the list of instances, the console breaks it open and 
        *shows an string of the make and model, proving that the instance existed.
        **/
        static void Main(string[] args)
        {
            CarComparisonEngine engine = new CarComparisonEngine();
            
            Console.WriteLine("Hello Elliasen Group!");

            
            while (!engine.CloseWindow)
            {
                Console.WriteLine("Enter 1 to calculate a list of vehicles ordered by Year");
                Console.WriteLine("Enter 2 to Calculate a list of vehicles ordered by Make and Model");
                Console.WriteLine("Enter 3 to Calculate a list of vehicles ordered by Price");
                Console.WriteLine("Enter 4 to Calculate a list of vehicles ordered by Value");
                Console.WriteLine("Enter 5 to Calculate a best fuel Consumption for given distance");
                Console.WriteLine("Enter 6 to return a random car from the list");
                Console.WriteLine("Enter 7 to return the average MPG by the given year");
                Console.WriteLine("Enter X to close this window");
                
                string functionNumber = Console.ReadLine();
                Console.WriteLine();
                
                engine.PlayerInput(functionNumber);
                Console.WriteLine();
            }

            Environment.Exit(0);
        }


       
    }
}
