using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Contexts
{
    internal interface IItemContext
    {
        IEnumerable<ItemModel> GetAll();
        ItemModel Get(int id);
        ItemModel Create(ItemModel item);
        void Remove(int id);
    }
}
