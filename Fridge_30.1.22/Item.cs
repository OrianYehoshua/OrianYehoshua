using System;


namespace Fridge_30._1._22
{
    class Item
    {
        public static int counter = 0;
        public int itemId { get; private set; }
        public string itemName { get; private set; }
        public int onShelf { get; set; }
        public ItemType itemType { get; }
        public Kosher kosher { get; }
        public DateTime expiryDate { get; set; }
        public double spaceToTakeUp { get; set; }

        public Item( string itemName ,int onShelf ,ItemType itemType, Kosher kosher ,DateTime expiryDate ,double spaceToTakeUp)
        {
            this.itemId= counter;
             this.itemName=itemName;
             this.onShelf=onShelf; 
             this.itemType=itemType;
             this.expiryDate=expiryDate;
             this.spaceToTakeUp=spaceToTakeUp;
            counter++;
        }

        public override string ToString()
        {
            return $"Item data: \n Item id: {this.itemId}\n Item name: {this.itemName}\n On which shelf the item?: {this.onShelf}\n Item type: {this.itemType}\n Kosher: {this.kosher}\n Expiry date: {this.expiryDate}\n How much space the item takes up on the shelf {this.spaceToTakeUp}\n";

        }
         public bool IsExpired()
        {
            if(DateTime.Today>=this.expiryDate)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}
