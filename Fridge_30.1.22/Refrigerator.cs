using System;
using System.Collections.Generic;


namespace Fridge_30._1._22
{
    class Refrigerator
    {
        public static int refrigeratorcounter = 0;
        public int refrigeratorId { get; private set; }
        public string refrigeratorModel { get; private set; }
        public string refrigeratorColor { get; private set; }
        public int numberOfShelves { get; private set; }
        public List<Shelf> shelves { get; set; }

        public Refrigerator(string refrigeratorModel, string refrigeratorColor, int numberOfShelves)
        {
            this.refrigeratorId = refrigeratorcounter;
            this.refrigeratorModel = refrigeratorModel;
            this.refrigeratorColor = refrigeratorColor;
            this.numberOfShelves = numberOfShelves;
            this.shelves = new List<Shelf>();
            refrigeratorcounter++;
        }
        public override string ToString()
        {
            return $"Refrigerator data: \n Refrigerator id: {this.refrigeratorId}\n Refrigerator model: {this.refrigeratorModel}\n Refrigerator color: {this.refrigeratorColor}\n Number of shelves: {this.numberOfShelves}\n Shelves list:\n {PrintShelves(this.shelves)}\n";
        }

        public string PrintShelves(List<Shelf> shelves)
        {
            string print = "";
            foreach (Shelf shelf in shelves)
            {
                print += shelf.ToString();
            }
            return print;
        }

        public double SpaceLeftInRefrigerator()
        {
            double currentSpace = 0;
            for (int i = 0; i < this.shelves.Count; i++)
            {
                currentSpace += this.shelves[i].SpaceLeftOnTheShelf();
            }
            return currentSpace;
        }

        public string InsertItemToRefrigerator(Item item)
        {
            int indexOfItemShelf = item.onShelf - 1;
            if (this.shelves[indexOfItemShelf].SpaceLeftOnTheShelf()>=item.spaceToTakeUp)
            {
               this.shelves[indexOfItemShelf].items.Add(item);
               return "the item added";
            }
            else
            {
                if (SpaceLeftInRefrigerator() != 0)
                {
                    Console.WriteLine("there is no place on this shelf, Please choose another shelf.");
                    int NewShelf = int.Parse(Console.ReadLine());
                    item.onShelf = NewShelf;
                    return InsertItemToRefrigerator(item);
                }
                else
                    return "the refrigerator is full";


            }
                      
        }

        public void RemoveItemFromRefrigerator(int itemId)
        {
            bool wasremoved = false;
            for (int i = 0; i < this.shelves.Count && wasremoved == false; i++)
            {
                if (this.shelves[i].RemoveItem(itemId) == "The item was removed successfully")
                {
                    wasremoved = true;
                }
            }
        }

        public void CleaningTheRefrigerator()
        {
            for (int i = 0; i < this.shelves.Count; i++)
            {
                this.shelves[i].CleaningTheShelf();
            }
        }

        public string WhatdoIWantToEat(Kosher kosher, ItemType type)
        {
            string print = "";      
            for (int i = 0; i < this.shelves.Count; i++)
            {
                print += this.shelves[i].returnItem(kosher, type);
            }
            return print;
        }

        public string SortedByExpiryDate()
        {
            List<Item> AllItems = new List<Item>();
            foreach (Shelf shelf in this.shelves)
            {
                AllItems.AddRange(shelf.items);
            }
            AllItems.Sort((date1, date2) => date1.expiryDate.CompareTo(date2.expiryDate));
            return AllItems.ToString();
        }

        public string sortShelvesByLeftSpace()
        {
            this.shelves.Sort((first, second) => first.spaceOfShelf.CompareTo(second.spaceOfShelf));
            return PrintShelves(this.shelves);
        }

        public void GettingReadyForShopping()
        {
            if (SpaceLeftInRefrigerator() != 29)
            {
                if (SpaceLeftInRefrigerator() < 20)
                {
                    CleaningTheRefrigerator();
                }
                if (SpaceLeftInRefrigerator() < 20)
                {
                    List<Item> removedItemsFromAllShelves = new List<Item>();
                    foreach (Shelf shelf in this.shelves)
                    {
                        removedItemsFromAllShelves.AddRange(shelf.RemoveItemsByExpireRangeAndKosher(3, Kosher.Dairy));
                        Console.WriteLine("All dairy products that are valid for less than three days have been removed");
                        if (SpaceLeftInRefrigerator() > 20) break;
                        removedItemsFromAllShelves.AddRange(shelf.RemoveItemsByExpireRangeAndKosher(7, Kosher.Meat));
                        Console.WriteLine("All meat products that are valid for less than a week have been removed");
                        if (SpaceLeftInRefrigerator() > 20) break;
                        removedItemsFromAllShelves.AddRange(shelf.RemoveItemsByExpireRangeAndKosher(1, Kosher.Parve));
                        Console.WriteLine("All parve products that are valid for less than a day have been removed");
                    }
                    if (SpaceLeftInRefrigerator() < 20)
                    {
                        Console.WriteLine("This is not the right time for shopping!");
                        foreach (Item item in removedItemsFromAllShelves)
                        {
                            InsertItemToRefrigerator(item);
                        }        
                    }
                    else
                    {
                        Console.WriteLine("\nRefrigerator is ready for shopping!\n");
                    }
                }
            }
            else
                Console.WriteLine("\nRefrigerator is ready for shopping!\n");
        }

       
           

    }
}
