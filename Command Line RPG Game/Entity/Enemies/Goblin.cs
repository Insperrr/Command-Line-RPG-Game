using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Entity.Enemies
{
    internal class Goblin : Enemy
    {
        public Goblin(int level) : base(level)
        {
            Name = "Goblin";
        }

        protected override void InitializeStats()
        {
            int baseHealth = 40;
            int baseAttack = 6;
            int baseDefence = 5;

            MaxHealth = baseHealth + (Level * 8);
            AttackPower = baseAttack + (Level * 2);
            Defence = baseDefence + (int)(Level * 1.2);

            Health = MaxHealth;
        }

        protected override void InitializeAbilities()
        {
            AddAbility(new Abilities.OffensiveAbilities.BasicAttack());
        }
    }
}
