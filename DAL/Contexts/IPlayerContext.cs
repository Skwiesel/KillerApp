using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Contexts
{
    internal interface IPlayerContext
    {
        IEnumerable<PlayerModel> GetAll();
        PlayerModel Get(int id);
        void Create(PlayerModel player);
    }
}
