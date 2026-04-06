using Command_Line_RPG_Game.Abilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Entity
{
    internal class Enemy : Character
    {
        public Enemy(string name, int maxHealth, int attack, int defence, List<Ability> abilities)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = MaxHealth;
            AttackPower = attack;
            Defence = defence;
            AbilityList = abilities;

        }
    }
}
