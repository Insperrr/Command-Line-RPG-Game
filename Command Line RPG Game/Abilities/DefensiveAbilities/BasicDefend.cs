using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.StatusEffect;

namespace Command_Line_RPG_Game.Abilities.DefensiveAbilities
{
    internal class BasicDefend : Ability
    {
        public int Cooldown { get; set; } = 2;
        public override void UseAbility(Character user, Character target)
        {
            user.Effects.Add(new BasicDefenceBoost().ApplyEffect(user));
            Console.WriteLine($"You brace yourself for the next attack, increasing your defence by 15.");
            Console.WriteLine(user.Effects[0].Duration + "Duration");
        }
    }
}
