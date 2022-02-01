using System;
using System.Collections.Generic;


namespace Fridge_30._1._22
{
    class Shelf
    {
        public static int Shelfcounter = 0;
        public int shelfId { get; private set; }
        public int floorNumber { get; private set; }
        public double spaceOfShelf { get; private set; }
        public List<Item> items { get; set; }

        public Shelf( int floorNumber, double spaceOfShelf)
        {
            this.shelfId = Shelfcounter;
            this.floorNumber = floorNumber;
            this.spaceOfShelf = spaceOfShelf;
            this.items = new List<Item>();
            Shelfcounter++;
        }
        public override string ToString()
        {
            return $"Shelf data: \n Shelf id: {this.shelfId}\n How much space is on the shelf?: {this.spaceOfShelf}\n The items that are on the shelf : {PrintItems()}\n";

        }

        public string PrintItems()
        {
            string print = "";
            foreach (Item item in this.items)
            {
                print += item.ToString();
            }
            return print;
        }
        public double SpaceLeftOnTheShelf()
        {
            double currentSpace = 0;
            for (int i = 0; i < this.items.Count; i++)
            {
                currentSpace += this.items[i].spaceToTakeUp;
            }
            return this.spaceOfShelf - currentSpace;
        }

        public string AddItem(Item item)
        {
            if (SpaceLeftOnTheShelf() > item.spaceToTakeUp)
            {
                items.Add(item);
                return "The item was added successfully";
            }
            else
                return "The item has not been added to the current shelf";
        }

        public string RemoveItem(int itemId)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].itemId == itemId)
                {
                    this.items.Remove(this.items[i]);
                    return $"{this.items[i]} was removed successfully";
                }               
            }
            return "item wasn't found";
            
        }

        public void CleaningTheShelf()
        {
            for (int i = 0; i <this.items.Count; i++)
            {
                if(this.items[i].IsExpired()==true)
                {
                    RemoveItem(this.items[i].itemId);
                }
            }
        }

        public List<Item> RemoveItemsByExpireRangeAndKosher(int days, Kosher kosher)
        {
             List<Item> RemovedItems = new List<Item>();
            for (int i = 0; i < this.items.Count; i++)
            {
                if((Math.Abs((DateTime.Now- this.items[i].expiryDate).Days)<days) && this.items[i].kosher==kosher)
                {
                    RemovedItems.Add(this.items[i]);
                    RemoveItem(this.items[i].itemId);
                }
            }
            return RemovedItems;
        }


        public List<Item> returnItem(Kosher kosher, ItemType type)
        {
            List<Item> returnItems = new List<Item>();
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].kosher==kosher && this.items[i].itemType == type && this.items[i].IsExpired()==false)
                {
                    returnItems.Add(this.items[i]);
                }
            }
            return returnItems;
        }

       
    }
}
