using System;
using Models;

namespace DAL
{
    public class CharacterLogic
    {
        public CharacterModel Attack(CharacterModel attacker, CharacterModel defender)
        {
            return attacker;
        }
        public CharacterModel Block(CharacterModel ch)
        {
            return ch;
        }
    }
}
