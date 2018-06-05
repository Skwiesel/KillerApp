using System;
using System.Collections.Generic;
using System.Text;
using Models;
using DAL.Contexts;

namespace DAL
{
    public class PlayerLogic
    {
        private IPlayerContext context;

        public PlayerLogic(StorageType storageType)
        {
            switch (storageType)
            {
                //case StorageType.Database: context = new PlayerDBContext(); break;
                case StorageType.Memory: context = new PlayerMemoryContext(); break;
            }
        }
        public PlayerModel Get(int id) => context.Get(id);
        public IEnumerable<PlayerModel> GetAll() => context.GetAll();
        public void Create(PlayerModel player) => context.Create(player);

        public ItemModel UseItem(int itemID)
        {
            return null;
        }

        public ItemModel EquipItem(int itemID)
        {
            return null;
        }

        public PlayerModel PlayerDie(PlayerModel player)
        {
            return new PlayerModel();
        }

        public PlayerModel UpgradeSkill(PlayerModel player)
        {
            return new PlayerModel();
        }
    }
}
