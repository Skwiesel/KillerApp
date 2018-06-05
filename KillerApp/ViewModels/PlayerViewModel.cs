using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KillerApp.ViewModels
{
    public class PlayerViewModel : CharacterViewModel
    {
        public int Charisma { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
    }
}
