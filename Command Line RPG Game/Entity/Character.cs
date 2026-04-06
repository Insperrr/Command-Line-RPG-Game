using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Entity
{
    internal abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Defence { get; set; }
        public int AttackPower { get; set; }
        public int MaxMana { get; set; } = 100;
        public int Mana { get; set; } = 100;
        public List<Abilities.Ability> AbilityList { get; set; } = new List<Abilities.Ability>();


    }
}
