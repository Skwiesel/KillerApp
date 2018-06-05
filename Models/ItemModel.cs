using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Stats { get; set; }
        public eItemType ItemType { get; set; }
        public eItemLoc ItemLoc { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public int HealthUp { get; set; }
        public int SpeedUp { get; set; }
        public int StrengthUp { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }
        public int CurrentDurability { get; set; }
        public int MaxDurability { get; set; }
        public ItemModel() { }
    }
}
