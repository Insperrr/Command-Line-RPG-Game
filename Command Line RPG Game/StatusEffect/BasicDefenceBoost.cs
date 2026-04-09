using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.StatusEffect
{
    internal class BasicDefenceBoost : StatusEffect
    {
        public int DefenseBoost { get; set; }
        public override int Duration { get; set; } = 1;
        protected Character Owner;

        public BasicDefenceBoost()
        {
            Value = 25;
            DefenseBoost = Value;
        }
        public override string GetDescription()
        {
            return $"Increase defence by {DefenseBoost} for {Duration} turn(s)";
        }
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
