using Command_Line_RPG_Game.Entity;
using Command_Line_RPG_Game.StatusEffect;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Abilities.OffensiveAbilities
{
    internal class SmallFireball : OffensiveAbility
    {
        public override string Name => "Small Fireball";
        public SmallFireball()
        {
            Cooldown = 0;
            ManaCost = 25;
            Damage = 5;
            AbilityDescription = "A small fireball that does 25 damage.";
        }
    }
}