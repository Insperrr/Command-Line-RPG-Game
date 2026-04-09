using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.Entity;



namespace Command_Line_RPG_Game.StatusEffect
{
    internal abstract class StatusEffect
    {
        public virtual int Duration { get; set; } = 1;
        public virtual int Value { get; set; } = 0;
        protected Character Owner;
        public virtual string Name { get; protected set; } = "Unnamed Status Effect";
        public virtual string GetDescription()
        {
            return $"{Name} (Duration: {Duration})";
        }
        public StatusEffect ApplyEffect(Character target)
        {
            Owner = target;
            Owner.OnTurnStart += UpdateEffect;
            ApplyBuff(target);
            return this;
        }
        public StatusEffect RemoveEffect()
        {
            Owner.OnTurnStart -= UpdateEffect;
            RemoveBuff(Owner);
            Owner.Effects.Remove(this);
            return this;
        }

        public abstract void ApplyBuff(Character target);
        public abstract void RemoveBuff(Character target);
        public virtual void UpdateEffect()
        {
            Duration--;
            if (Duration == 0)
            {
                RemoveEffect();
            }
        }

    }

}
