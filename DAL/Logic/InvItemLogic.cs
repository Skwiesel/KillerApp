using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Contexts;

namespace DAL
{
    public class InvItemLogic
    {
        private IItemContext context;

        public InvItemLogic(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Database: context = new InvItemDBContext(); break;
                case StorageType.Memory: context = new InvItemMemoryContext(); break;
            }
        }
        public ItemModel Get(int id) => context.Get(id);
        public IEnumerable<ItemModel> GetAll() => context.GetAll();
        public void Create(ItemModel item) => context.Create(item);

        public ItemModel Use(ItemModel item, PlayerModel player)
        {
            if(item.HealthUp != 0)
            {
                for (int i = 0; i < item.HealthUp; i++)
                {
                    if (player.CurrentHealth < player.MaxHealth)
                    {
                        player.CurrentHealth++;
                    }
                }
            }
            if(item.SpeedUp != 0)
            {
                player.Speed += item.SpeedUp;
            }
            if(item.StrengthUp != 0)
            {
                player.Strength += item.StrengthUp;
            }

            context.Remove(item.Id);
            return item;
        }
        public ItemModel Degrade(ItemModel item)
        {
            return null;
        }
        public ItemModel Transfer(ItemModel item)
        {
            if (item.ItemLoc == eItemLoc.Shop)
            {
                context.Create(item);
            }
            else if (item.ItemLoc == eItemLoc.Inventory)
            {
                context.Remove(item.Id);
            }
            return item;
        }
        public ItemModel Sell(int itemID, PlayerModel player)
        {
            ItemModel item = Get(itemID);
            Transfer(item);
            player.Money += item.SellPrice;
            return item;
        }
        public ItemModel Repair(ItemModel item, PlayerModel player)
        {
            int price = item.MaxDurability - item.CurrentDurability;
            if(player.Money - price >= 0)
            {
                player.Money -= price;
                item.CurrentDurability = item.MaxDurability;
            }
            return item;
        }
    }
}
