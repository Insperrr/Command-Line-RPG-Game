using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.Entity;



namespace Command_Line_RPG_Game.StatusEffect
{
    internal abstract class StatusEffect
    {
        public virtual int Duration { get; set; }

        public abstract StatusEffect ApplyEffect(Character target);
        public virtual StatusEffect RemoveEffect(Character target)
        {
            // Default implementation does nothing, can be overridden by specific status effects if needed
            return this;
        }
    }

}
