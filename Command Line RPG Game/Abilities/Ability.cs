using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Command_Line_RPG_Game.Abilities
{
    internal abstract class Ability
    {
        public string Name { get; set; }
        public int Cooldown { get; set; } = 0;
        public int CurrentCooldown { get; set; } = 0;
        public int ManaCost { get; set; } = 0;


        public abstract void UseAbility(Character user, Character target);
        public bool Use(Character user, Character target)
        {
            if (!CheckConditionsValid(user))
            {
                return false;
            }
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
    }
}