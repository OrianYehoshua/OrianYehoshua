using System;
using System.Collections.Generic;

namespace Fridge_30._1._22
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("                     Welcome to the Refrigerator system                            ");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            Console.WriteLine("\nPlease enter refrigerator details\n");
            Refrigerator refrigerator = consoleApplication.EnterRefrigerator();

            List<Refrigerator> refrigerators = new List<Refrigerator>();
            refrigerators.Add(refrigerator);

            Console.WriteLine("\nWould you like to add details of more refrigerators? (Yes or No)\n");
            string input = Console.ReadLine();
            while(input=="Yes")
            {
                refrigerators.Add(consoleApplication.EnterRefrigerator());
                Console.WriteLine("\nWould you like to continue adding refrigerators? (Yes or No)\n");
                input = Console.ReadLine();
            }


            consoleApplication.ConsoleApplication(refrigerator, consoleApplication.Menu(), refrigerators);


        }

        
        
    }
     
}
