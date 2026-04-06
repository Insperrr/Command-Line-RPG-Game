using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Abilities.OffensiveAbilities
{
    internal class BasicAttack : OffensiveAbility
    {
        public BasicAttack()
        {
            Name = "Basic Attack";
            Cooldown = 0;
            ManaCost = 0;
            Damage = 1;
        }



        public override void UseAbility(Character user, Character target)
        {
            int damage = user.AttackPower - target.Defence;
            if (damage < 0) damage = 0;
            target.Health -= damage;
            Console.WriteLine($"{user.Name} deals {damage} damage!");
        }
    }
}
