using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.Abilities;

namespace Command_Line_RPG_Game.Entity
{
    internal class Player : Character
    {
        public Player(string name)
        {
            Name = name;
            MaxHealth = 100;
            Health = MaxHealth;
            Defence = 10;
            AttackPower = 10;
            AbilityList.Add(new Abilities.OffensiveAbilities.BasicAttack());
        }
    }
}
