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
            MaxHealth = 80 + (Level - 1) * 8;
            Health = MaxHealth;
            AttackPower = 12 + (Level - 1) * 2;
            Defence = 8 + (Level - 1) * 1;
        }

        protected override void InitializeAbilities()
        {
            AddAbility(new Abilities.OffensiveAbilities.BasicAttack());
        }
    }
}
