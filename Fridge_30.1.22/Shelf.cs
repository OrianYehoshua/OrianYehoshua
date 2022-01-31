using System;
using System.Collections.Generic;
using System.Text;

namespace Fridge_30._1._22
{
    class Shelf
    {
        public string shelfId { get; private set; }
        public int floorNumber { get; private set; }
        public double spaceOfShelf { get; private set; }
        public List<Item> items { get; set; }

        public Shelf(string shelfId, int floorNumber, double spaceOfShelf)
        {
            this.shelfId = shelfId;
            this.floorNumber = floorNumber;
            this.spaceOfShelf = spaceOfShelf;
            this.items = new List<Item>();
        }
        public override string ToString()
        {
            return $"Shelf data: \n Shelf id: {this.shelfId}\n How much space is on the shelf?: {this.spaceOfShelf}\n The items that are on the shelf : {this.items}\n";

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

        public string RemoveItem(string itemId)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].itemId == itemId)
                {
                    this.items.Remove(this.items[i]);
                    return "The item was removed successfully";
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
