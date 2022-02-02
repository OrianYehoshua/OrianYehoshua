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
            return $"Shelf data: \n Shelf id: {this.shelfId}\n How much space is on the shelf?: {this.spaceOfShelf}\n The items that are on the shelf : {PrintItems(this.items)}\n";

        }

        public string PrintItems(List<Item> items)
        {
            string print = "";
            foreach (Item item in items)
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

      

        public string RemoveItem(int itemId)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].itemId == itemId)
                {
                    this.items.Remove(this.items[i]);
                    return "item was removed successfully";
                }               
            }
            return "item wasn't found";
            
        }

        public void CleaningTheShelf()
        {
            for (int i = 0; i <this.items.Count; i++)
            {
                if(this.items[i].IsExpired()==false)
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
            Console.WriteLine(PrintItems(RemovedItems));
            return RemovedItems;
        }


        public string returnItem(Kosher kosher, ItemType type)
        {
            List<Item> returnItems = new List<Item>();
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].kosher==kosher && this.items[i].itemType == type && this.items[i].IsExpired()==false)
                {
                    returnItems.Add(this.items[i]);
                }
            }
            return PrintItems(returnItems);
        }

       
    }
}
