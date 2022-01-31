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

        public void RemoveItemFromRefrigerator(string itemId)
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


    }
}
