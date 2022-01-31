using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge_30._1._22
{
    class consoleApplication
    {
        public static void consoleApplication(Refrigerator refrigerator)
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
                    input = Console.ReadLine();
                    ItemType type2 = EnterItemType(input);
                    Console.WriteLine("Enter item Kosher (Meat, Dairy, Parve)");
                    input = Console.ReadLine();
                    Kosher kosher2 = EnterKosher(input);
                    refrigerator.WhatdoIWantToEat(kosher2, type2);
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 100:
                    break;
                default:
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



    }
}
