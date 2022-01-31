using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge_30._1._22
{
    class Refrigerator
    {
        public string refrigeratorId { get; private set; }
        public string refrigeratorModel { get; private set; }
        public string refrigeratorColor { get; private set; }
        public int numberOfShelves { get; private set; }
        public List<Shelf> shelves { get; set; }

        public Refrigerator(string refrigeratorId, string refrigeratorModel, string refrigeratorColor, int numberOfShelves)
        {
            this.refrigeratorId = refrigeratorId;
            this.refrigeratorModel = refrigeratorModel;
            this.refrigeratorColor = refrigeratorColor;
            this.numberOfShelves = numberOfShelves;
            this.shelves = new List<Shelf>();
        }
        public override string ToString()
        {
            return $"Refrigerator data: \n Refrigerator id: {this.refrigeratorId}\n Refrigerator model: {this.refrigeratorModel}\n Refrigerator color: {this.refrigeratorColor}\n Number of shelves: {this.numberOfShelves}\n Shelves list: {this.shelves}\n";
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

        public void InsertItemToRefrigerator(Item item)
        {
            bool wasInserted = false;
            for (int i = 0; i < this.shelves.Count && wasInserted==false; i++)
            {
                if(this.shelves[i].AddItem(item)== "The item was added successfully")
                {
                    wasInserted = true;
                }
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

        public void WhatdoIWantToEat(Kosher kosher, ItemType type)
        {
            for (int i = 0; i < this.shelves.Count; i++)
            {
                this.shelves[i].returnItem(kosher, type);
            }
            
        }

        public List<Item> SortedByExpiryDate()
        {
            List<Item> AllItems = new List<Item>();
            foreach (Shelf shelf in this.shelves)
            {
                AllItems.AddRange(shelf.items);
            }
            AllItems.Sort((date1, date2) => date1.expiryDate.CompareTo(date2.expiryDate));
            return AllItems;
        }

        public List<Shelf> sortSelvesByLeftSpace()
        {
            this.shelves.Sort((first, second) => first.spaceOfShelf.CompareTo(second.spaceOfShelf));
            return this.shelves;
        }

        //TODO:	הפונקציה תמיין ותחזיר את כלל המקררים לפי מקום פנוי שנשאר בהם 

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
