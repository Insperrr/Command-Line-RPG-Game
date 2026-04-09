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
            Damage = 10;
            AbilityDescription = "A basic attack that deals 10 damage";
        }
    }
}
