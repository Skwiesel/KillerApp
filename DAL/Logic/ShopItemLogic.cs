using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Contexts;

namespace DAL
{
    public class ShopItemLogic
    {
        private IItemContext context;

        public ShopItemLogic(StorageType storageType)
        {
            switch (storageType)
            {
                //case StorageType.Database: context = new ItemDBContext(); break;
                case StorageType.Memory: context = new ShopItemMemoryContext(); break;
            }
        }
        public ItemModel Get(int id) => context.Get(id);
        public IEnumerable<ItemModel> GetAll() => context.GetAll();
        public void Create(ItemModel item) => context.Create(item);

        public ItemModel Transfer(ItemModel item)
        {
            if(item.ItemLoc == eItemLoc.Shop)
            {
                context.Remove(item.Id);
            }
            else if(item.ItemLoc == eItemLoc.Inventory)
            {
                context.Create(item);
            }
            return item;
        }
        public ItemModel Buy(int itemID, PlayerModel player)
        {
            ItemModel item = Get(itemID);
            if (player.Money - item.BuyPrice > 0)
            {
                Transfer(item);
                player.Money -= item.BuyPrice;
            }
            return item;
        }
    }
}
