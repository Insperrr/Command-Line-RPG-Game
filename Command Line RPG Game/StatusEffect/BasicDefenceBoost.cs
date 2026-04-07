using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.StatusEffect
{
    internal class BasicDefenceBoost : StatusEffect
    {
        public int DefenseBoost { get; set; } = 10;
        public override int Duration { get; set; } = 1;


        public override StatusEffect ApplyEffect(Character target)
        {
            target.Defence += DefenseBoost;
            return this;
        }
        public override StatusEffect RemoveEffect(Character target)
        {
            target.Defence -= DefenseBoost;
            return this;
        }
    }
}
