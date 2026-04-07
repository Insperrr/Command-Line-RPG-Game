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
        }
        public override string Description
        {
            get
            {
                var preview = CreateEffect();
                return $"Increase defence by {((BasicDefenceBoost)preview).DefenseBoost} " +
                       $"- Cooldown: {CurrentCooldown}/{Cooldown} - Duration: {preview.Duration}";
            }
        }
        protected override StatusEffect.StatusEffect CreateEffect()
        {
            return new BasicDefenceBoost();
        }
        public override void UseAbility(Character user, Character? target)
        {
            BasicDefenceBoost defenceBoost = CreateEffect() as BasicDefenceBoost;
            if (defenceBoost == null) { throw new InvalidOperationException("Effect must be of type BasicDefenceBoost"); }
            defenceBoost.ApplyEffect(user);
            user.Effects.Add(defenceBoost);

            Console.WriteLine($"You brace yourself, increasing defence by {defenceBoost.DefenseBoost}.");
        }
    }
}
