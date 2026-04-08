using Command_Line_RPG_Game.Abilities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Command_Line_RPG_Game.Entity
{
    internal class Enemy : Character
    {
        public Enemy(string name, int level, int maxHealth, int attack, int defence, List<Ability> abilities)
        {
            Name = name;
            AbilityList = abilities;

            Level = level;

            MaxHealth = 50 + (level * 10);
            Health = MaxHealth;
            AttackPower = 8 + (level * 2);
            Defence = 8 + (int)(level * 1.5);
        }
    }
}
