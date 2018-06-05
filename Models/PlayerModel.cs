using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PlayerModel : CharacterModel
    {
        public IEnumerable<ItemModel> Inventory { get; set; }
        public int Charisma { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
    }
}
