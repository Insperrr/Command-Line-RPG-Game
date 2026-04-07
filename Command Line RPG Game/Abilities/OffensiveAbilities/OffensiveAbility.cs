using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Abilities.OffensiveAbilities
{
    internal abstract class OffensiveAbility : Ability
    {
        public int Damage { get; set; } = 0;

        protected int CalculateDamage(Character user, Character target)
        {
            int CalculatedDamage = (int)(user.AttackPower * Damage * (100.0 / (100 + target.Defence)));
            return Math.Max(CalculatedDamage, 1);
        }
        public override void UseAbility(Character user, Character? target)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target), "Target is required for offensive abilities.");
            
            int damage = CalculateDamage(user, target);
            target.Health -= damage;
            if (target.Health < 0) target.Health = 0;

            Console.WriteLine($"{user.Name} uses {Name}, dealing {damage} damage to {target.Name}!\n");

            OnHitExtra(user, target);
        }

        public virtual void OnHitExtra(Character user, Character target)
        {

        }
    }
}
