using System;
using System.Collections.Generic;


namespace Fridge_30._1._22
{
     abstract class consoleApplication
    {

        public static int Menu()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("                                        Menu                                       ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("\nPress 1: Print all the items on the refrigerator and all its contents\n" +
                "Press 2: To know how much space is left in the refrigerator\n" +
                "Press 3: Put an item in the refrigerator\n" +
                "Press 4: Remove item from refrigerator\n" +
                "Press 5: To clean the refrigerator\n" +
                "Press 6: Print products according to what you feel like eating\n" +
                "Press 7: Print the products arranged by their expiration date\n" +
                "Press 8: Print all the shelves arranged according to the free space left on them\n" +
                "Press 9: Print all the refrigerators are arranged according to the free space left in them\n" +
                "Press 10: Prepare the refrigerator for shopping\n" +
                "Press 100: Close the system\n");
            int input = int.Parse(Console.ReadLine());
            return input;
        }
        public static void ConsoleApplication(Refrigerator refrigerator, int choose, List<Refrigerator> refrigerators)
        {
            switch (choose)
            {
                case 1:
                    Console.WriteLine(refrigerator.ToString());
                    break;
                case 2:
                    Console.WriteLine(refrigerator.SpaceLeftInRefrigerator());
                    break;
                case 3:
                    Item item = EnterItem();
                    refrigerator.InsertItemToRefrigerator(item);
                    break;
                case 4:
                    Console.WriteLine("Enter item id to remove");
                    int itemId = int.Parse(Console.ReadLine());
                    refrigerator.RemoveItemFromRefrigerator(itemId);
                    break;
                case 5:
                    Console.WriteLine("All items that inspected: ");
                    foreach (Shelf shelf in refrigerator.shelves)
                    {
                        shelf.items.ToString();
                    }
                    refrigerator.CleaningTheRefrigerator();
                    break;
                case 6:
                    Console.WriteLine("what do you want to eat? enter kosher and type");
                    Console.WriteLine("Enter item type (Food or Drink)");
                    string input = Console.ReadLine();
                    ItemType type2 = EnterItemType(input);
                    Console.WriteLine("Enter item Kosher (Meat, Dairy, Parve)");
                    input = Console.ReadLine();
                    Kosher kosher2 = EnterKosher(input);
                    refrigerator.WhatdoIWantToEat(kosher2, type2);
                    break;
                case 7:
                    Console.WriteLine("All items arranged by their expiration date:\n" + refrigerator.SortedByExpiryDate());
                    break;
                case 8:
                    Console.WriteLine("All the shelves arranged according to the free space left on them (from large to small):\n" + refrigerator.sortShelvesByLeftSpace()); 
                    break;
                case 9:
                    Console.WriteLine("All refrigerators  arranged according to the available space left in them:\n"+sortRefrigeratorsByLeftSpace(refrigerators)); 
                    break;
                case 10:
                    refrigerator.GettingReadyForShopping();
                    break;
                case 100:
                    Console.WriteLine("The system has shut down");
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }



        }
        public  static ItemType EnterItemType(string input)
        {
            bool entered = false;
            ItemType itemType = ItemType.Drink;
            while (entered == false)
            {
                if (input == ItemType.Drink.ToString())
                {
                    itemType = ItemType.Drink;
                    entered = true;
                }
                else if (input == ItemType.Food.ToString())
                {
                    itemType = ItemType.Food;
                    entered = true;
                }
                else
                    Console.WriteLine("enter again");
            }
            return itemType;

        }

        public static Kosher EnterKosher(string input)
        {
            bool entered = false;
            Kosher kosher = Kosher.Meat;
            while (entered == false)
            {
                if (input == Kosher.Meat.ToString())
                {
                    kosher = Kosher.Meat;
                    entered = true;
                }
                else if (input == Kosher.Dairy.ToString())
                {
                    kosher = Kosher.Dairy;
                    entered = true;
                }
                else if (input == Kosher.Parve.ToString())
                {
                    kosher = Kosher.Parve;
                    entered = true;
                }
                else
                    Console.WriteLine("enter again");
            }
            return kosher;
    }

        public static Item EnterItem()
        {
            Console.WriteLine("Enter item name");
            string itemName = Console.ReadLine();
            Console.WriteLine("Enter item shelf");
            string onShelf = Console.ReadLine();
            Console.WriteLine("Enter item type (Food or Drink)");
            string input = Console.ReadLine();
            ItemType itemType = EnterItemType(input);
            Console.WriteLine("Enter item Kosher (Meat, Dairy, Parve)");
            input = Console.ReadLine();
            Kosher kosher = EnterKosher(input);
            Console.WriteLine("Enter day of expiry date");
            int day = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month of expiry date");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter year of expiry date");
            int year = int.Parse(Console.ReadLine());
            DateTime expiryDate = new DateTime(year, month, day);
            Console.WriteLine("How much space the item takes up ");
            double spaceToTakeUp = double.Parse(Console.ReadLine());
            Item item = new Item(itemName, onShelf, itemType, kosher, expiryDate, spaceToTakeUp);
            return item;
        }

        public static Shelf EnterShelf()
        {
            Console.WriteLine("Enter The floor number of the shelf");
            int floorNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("How much space is on the shelf? Place is measured in cm");
            double spaceOfShelf=double.Parse(Console.ReadLine());          
            Shelf shelf = new Shelf(floorNumber, spaceOfShelf);
            return shelf;
        }

        public static Refrigerator EnterRefrigerator()
        {
            Console.WriteLine("Enter refrigerator model");
            string refrigeratorModel = Console.ReadLine();
            Console.WriteLine("Enter refrigerator color");
            string refrigeratorColor = Console.ReadLine();
            Console.WriteLine("Enter number of shelves");
            int numberOfShelves = int.Parse(Console.ReadLine());
            Refrigerator refrigerator = new Refrigerator(refrigeratorModel, refrigeratorColor, numberOfShelves);
            for (int i = 0; i < numberOfShelves; i++)
            {
                refrigerator.shelves.Add(EnterShelf());
            }
            Console.WriteLine("Would you like to put items in the refrigerator? (Yes or No)");
            string input = Console.ReadLine();
            while (input == "Yes")
            {
                refrigerator.InsertItemToRefrigerator(EnterItem());
                if (refrigerator.SpaceLeftInRefrigerator() != 0)
                {
                    Console.WriteLine("Would you like to continue putting items on the shelf? (Yes or No)");
                    input = Console.ReadLine();
                }
                else
                {
                    input = "No";
                    Console.WriteLine("There is no space in the fridge");
                }

            }
            return refrigerator;
        }

        public static List<Refrigerator> sortRefrigeratorsByLeftSpace(List<Refrigerator> refrigerators)
        {
            refrigerators.Sort((first, second) => first.SpaceLeftInRefrigerator().CompareTo(second.SpaceLeftInRefrigerator()));
            return refrigerators;
        }

    }
}
