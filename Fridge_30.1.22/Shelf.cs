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
    }
}
