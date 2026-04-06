using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.Abilities;

namespace Command_Line_RPG_Game.Entity
{
    internal class Player : Character
    {
        public Player(string name)
        {
            Name = name;
            MaxHealth = 100;
            Health = MaxHealth;
            Defence = 10;
            AttackPower = 10;
            AbilityList.Add(new Abilities.OffensiveAbilities.BasicAttack());
            AbilityList.Add(new Abilities.DefensiveAbilities.BasicDefend());
        }

        public Ability ChooseAbility()
        {
            Console.WriteLine("Choose ability:");
            for (int i = 0; i < AbilityList.Count; i++)
                Console.WriteLine($"{i + 1}: {AbilityList[i].Name}");

            int choice = int.Parse(Console.ReadLine()) - 1;
            return AbilityList[choice];
        }

        public void UpdateEffects()
        {
            for (int i = Effects.Count - 1; i >= 0; i--)
            {
                Effects[i].Duration--;
                if (Effects[i].Duration <= 0)
                {
                Effects[i].RemoveEffect(this);
                Effects.RemoveAt(i);
                }
            }
        }
    }
}
