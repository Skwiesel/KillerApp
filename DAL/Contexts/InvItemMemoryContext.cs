using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAL.Contexts
{
    internal class InvItemMemoryContext : IItemContext
    {
        private static List<ItemModel> items = new List<ItemModel>();
        private static bool isInitialized = false;

        public InvItemMemoryContext()
        {
            if (!isInitialized)
            {
                Create(new ItemModel() { Name = "Iron Sword", ItemType = eItemType.Weapon, Id = 0, Damage = 10, MaxDurability = 200, CurrentDurability = 125 });
                Create(new ItemModel() { Name = "Speed Potion II", ItemType = eItemType.Consumable, HealthUp = 0, SpeedUp = 5, StrengthUp = 0 });
                Create(new ItemModel() { Name = "Leather Armor", ItemType = eItemType.Armour, Defense = 10, MaxDurability = 100, CurrentDurability = 90 });
                Create(new ItemModel() { Name = "Strength Potion I", ItemType = eItemType.Consumable, HealthUp = 0, SpeedUp = 0, StrengthUp = 3 });

                isInitialized = true;
            }
        }

        public ItemModel Create(ItemModel item)
        {
            item.ItemLoc = eItemLoc.Inventory;
            items.Add(item);
            item.Id = GetNextId();
            return item;
        }
        public void Remove(int id) => items.Remove(Get(id));
        public ItemModel Get(int id) => items.Single(i => i.Id == id);
        public IEnumerable<ItemModel> GetAll() => items.Where(i => i.ItemLoc == eItemLoc.Inventory);
        private int GetNextId() => items.Max(i => i.Id) + 1;
    }
}
