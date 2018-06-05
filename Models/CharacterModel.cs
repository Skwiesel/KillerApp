using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public abstract class CharacterModel
    {
        public int Id { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxStamina { get; set; }
        public int CurrentStamina { get; set; }
        public float Speed { get; set; }
        public int Strength { get; set; }
        public int Money { get; set; }
    }
}
