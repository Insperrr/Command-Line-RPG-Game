using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.StatusEffect
{
    internal class BasicDefenceBoost : StatusEffect
    {
        public int DefenseBoost { get; set; } = 25;
        public override int Duration { get; set; } = 1;
        protected Character Owner;

        public override void ApplyBuff(Character target)
        {
            Owner = target;
            Owner.Defence += DefenseBoost;
        }
        public override void RemoveBuff(Character target)
        {
            Owner.Defence -= DefenseBoost;
        }
     }
}
