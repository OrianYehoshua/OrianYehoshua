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

            //Console.WriteLine("\nPlease enter refrigerator details\n");
            //Refrigerator refrigerator = consoleApplication.EnterRefrigerator();
            Refrigerator refrigerator = new Refrigerator("11", "Red", 2);
            refrigerator.shelves.Add(new Shelf(1, 15));
            refrigerator.shelves[0].items.Add(new Item("Banana", 1, ItemType.Food, Kosher.Parve, new DateTime(2022, 2, 5), 8));
            refrigerator.shelves.Add(new Shelf(2, 10));
            refrigerator.shelves[1].items.Add(new Item("Eggs", 2, ItemType.Food, Kosher.Parve, new DateTime(2022, 2, 10), 9));
            Refrigerator refrigerator2 = new Refrigerator("123", "black", 2);
            refrigerator2.shelves.Add(new Shelf(1, 22));
            refrigerator2.shelves[0].items.Add(new Item("Milk", 1, ItemType.Drink, Kosher.Dairy, new DateTime(2022, 2, 2), 8));
            refrigerator2.shelves.Add(new Shelf(2, 15));
            refrigerator2.shelves[1].items.Add(new Item("Meat", 2, ItemType.Food, Kosher.Meat, new DateTime(2022, 2, 6), 15));


            List<Refrigerator> refrigerators = new List<Refrigerator>();
            refrigerators.Add(refrigerator);
            refrigerators.Add(refrigerator2);


            //Console.WriteLine("\nWould you like to add details of more refrigerators? (Yes or No)\n");
            //string input = Console.ReadLine();
            //while(input=="Yes")
            //{
            //    refrigerators.Add(consoleApplication.EnterRefrigerator());
            //    Console.WriteLine("\nWould you like to continue adding refrigerators? (Yes or No)\n");
            //    input = Console.ReadLine();
            //}


            consoleApplication.ConsoleApplication(refrigerator2, consoleApplication.Menu(), refrigerators);


        }

        
        
    }
     
}
