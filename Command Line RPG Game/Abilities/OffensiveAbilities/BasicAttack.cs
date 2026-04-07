using Command_Line_RPG_Game.Entity;
using Command_Line_RPG_Game.StatusEffect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Abilities.OffensiveAbilities
{
    internal class BasicAttack : OffensiveAbility
    {
        public override string Name => "Basic Attack";
        public BasicAttack()
        { 
            Cooldown = 0;
            ManaCost = 0;
            Damage = 1;
        }

        public override string Description
        {
            get
            {
                var preview = CreateEffect();
                return $"A Basic Attack That deals 1 damage - No Cooldown";
            }
        }
    }
}
