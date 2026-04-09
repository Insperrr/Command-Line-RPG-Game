using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.StatusEffect;

namespace Command_Line_RPG_Game.Abilities.DefensiveAbilities
{
    internal class BasicDefend : DefencesiveAblility
    {

        public BasicDefend()
        {
            Cooldown = 2;
            EffectId = "BasicDefenceBoost";
        }
        public override void UseAbility(Character user, Character? target)
        {
            var effect = GetEffect();
            if (effect != null)
            {
                user.ApplyStatusEffect(effect);
                Console.WriteLine($"You brace yourself, increasing defence by {((BasicDefenceBoost)effect).DefenseBoost}.");
            }
        }
    }
}
