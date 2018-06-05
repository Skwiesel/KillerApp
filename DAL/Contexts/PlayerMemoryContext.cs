using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;

namespace DAL.Contexts
{
    internal class PlayerMemoryContext : IPlayerContext
    {
        private static List<PlayerModel> players = new List<PlayerModel>();
        private static bool isInitialized = false;

        public PlayerMemoryContext()
        {
            if (!isInitialized)
            {
                Create(new PlayerModel() { Id = 0, Level = 25, Experience = 1723, MaxHealth = 300, CurrentHealth = 200, Strength = 1, Speed = 3, Money = 5820 });
                isInitialized = true;
            }
        }

        public void Create(PlayerModel player)
        {
            players.Add(player);
            player.Id = GetNextId();
        }

        public PlayerModel Get(int id) => players.Single(i => i.Id == id);
        public IEnumerable<PlayerModel> GetAll() => players;
        private int GetNextId() => players.Max(i => i.Id) + 1;
    }
}
