using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

namespace Command_Line_RPG_Game.Abilities
{
    internal abstract class Ability
    {
        public virtual string Name => Regex.Replace(GetType().Name, "(\\B[A-Z])", " $1");
        public virtual int Cooldown { get; set; } = 0;
        public virtual string Description => "No description provided.";
        public int CurrentCooldown { get; set; } = 0;
        public int ManaCost { get; set; } = 0;
        

        public void ApplyCooldown()
        {
            CurrentCooldown = Cooldown;
        }
        public abstract void UseAbility(Character user, Character target);

        protected virtual StatusEffect.StatusEffect CreateEffect()
        {
            return null;
        }
        public bool Use(Character user, Character target)
        {
            if (!CheckConditionsValid(user))
            {
                return false;
            }
            ApplyCooldown();
            UseAbility(user, target);
            return true;
        }

        private bool CheckConditionsValid(Character user)
        {
            if (CurrentCooldown > 0)
            {
                Console.WriteLine($"{Name} is on cooldown for {CurrentCooldown} more turns.");
                return false;
            }
        else if (user.Mana < ManaCost)
            {
                Console.WriteLine($"{user.Name} does not have enough mana to use {Name}.");
                return false;
            }
        return true;
        }

        public void UpdateCooldown()
        {
            if (CurrentCooldown > 0)
            {
                CurrentCooldown--;
            }
        }
    }
}