using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAL.Contexts
{
    internal class ShopItemMemoryContext : IItemContext
    {
        private static List<ItemModel> items = new List<ItemModel>();
        private static bool isInitialized = false;

        public ShopItemMemoryContext()
        {
            if (!isInitialized)
            {
                Create(new ItemModel() { Name = "Strength Potion III", ItemType = eItemType.Consumable, Id = 0, BuyPrice = 90, HealthUp = 0, SpeedUp = 0, StrengthUp = 5 });
                Create(new ItemModel() { Name = "Iron Armour", ItemType = eItemType.Armour, BuyPrice = 500, Defense = 20, MaxDurability = 200, CurrentDurability = 200 });
                Create(new ItemModel() { Name = "Silver Sword", ItemType = eItemType.Weapon, BuyPrice = 150, Damage = 20, MaxDurability = 80, CurrentDurability = 80 });
                Create(new ItemModel() { Name = "Leather Armor", ItemType = eItemType.Armour, BuyPrice = 200, Defense = 10, MaxDurability = 100, CurrentDurability = 100 });
                Create(new ItemModel() { Name = "Health Potion I", ItemType = eItemType.Consumable, BuyPrice = 30, HealthUp = 20, SpeedUp = 0, StrengthUp = 0 });

                isInitialized = true;
            }
        }
        public ItemModel Create(ItemModel item)
        {
            item.SellPrice = item.BuyPrice;
            item.ItemLoc = eItemLoc.Shop;
            items.Add(item);
            item.Id = GetNextId();
            return item;
        }
        public void Remove(int id) => items.Remove(Get(id));
        public ItemModel Get(int id) => items.Single(i => i.Id == id);
        public IEnumerable<ItemModel> GetAll() => items.Where(i => i.ItemLoc == eItemLoc.Shop);
        private int GetNextId() => items.Max(i => i.Id) + 1;
    }
}
