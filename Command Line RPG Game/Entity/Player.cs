using Command_Line_RPG_Game.Abilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Command_Line_RPG_Game.Entity
{
    internal class Player : Character
    {
        public int Gold { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
            Level = 1;
            LevelUpStats();
            AddAbility(new Abilities.OffensiveAbilities.BasicAttack());
            AddAbility(new Abilities.DefensiveAbilities.BasicDefend());
        }

        public void BattleWin()
        {
            Console.WriteLine($"\n{Colorize($"{Name} won the battle!", ConsoleColor.Green)}");
            Gold += (Level * 100);
            Console.WriteLine($"\n{Colorize($"{Name} gained {Gold} Gold!", ConsoleColor.Yellow)}\n");
            LevelUp();
        }   
        public void ResetStats()
        {
            Health = MaxHealth;
            Mana = MaxMana;
            TemporaryDefence = 0;
            Effects.Clear();
            foreach (var ability in AbilityList)
                ability.CurrentCooldown = 0;
        }
        public void SetName()
        {
            while (true)
            {
                Console.Write("Enter Your Username: ");
                Name = Console.ReadLine();

                // Validation checks
                if (string.IsNullOrWhiteSpace(Name))
                {
                    Console.WriteLine("Name cannot be empty. Try again.\n");
                    continue;
                }

                if (Name.Length < 3)
                {
                    Console.WriteLine("Name must be at least 3 characters long.\n");
                    continue;
                }

                if (Name.Length > 15)
                {
                    Console.WriteLine("Name must be 15 characters or less.\n");
                    continue;
                }

                break;
            }
        }

        private void LevelUp()
        {
            Level++;
            Console.WriteLine($"{Colorize($"{Name} leveled up! Now Level {Level}", ConsoleColor.Green)}");

            LevelUpStats();
        }

        private string Colorize(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            return "";
        }

        private void LevelUpStats()
        {
            MaxHealth = 100 + (Level - 1) * 10;
            AttackPower = 10 + (Level - 1) * 2;
            Defence = 10 + (int)((Level - 1) * 1.5);

            Health = MaxHealth; // heal on level up
        }
        public Ability ChooseAbility()
        {
            Console.WriteLine("Choose ability:");
            for (int i = 0; i < AbilityList.Count; i++)
                Console.Write($"{i + 1}: {AbilityList[i].Name} || ");
            Console.WriteLine();
            Console.Write("(Press 5 to view Stats, 6 to view Ability Descriptions):    ");

            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice == 4)
            {
                Console.WriteLine("\nStats:");
                Console.WriteLine($"Name: {Name}");
                Console.WriteLine($"Health: {Health}/{MaxHealth}");
                Console.WriteLine($"Attack Power: {AttackPower}");
                Console.WriteLine($"Defence: {Defence}\n\n");
                return ChooseAbility();
            }
            if (choice == 5)
            {
                Console.WriteLine("\nAbility Descriptions:");
                for (int i = 0; i < AbilityList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}: {AbilityList[i].Name} - {AbilityList[i].Description}");
                }
                Console.WriteLine();
                return ChooseAbility();
            }
            if (choice < 0 || choice >= AbilityList.Count)
            {
                Console.WriteLine("Invalid choice, try again.");
                return ChooseAbility();
            }
            if (AbilityList[choice].CurrentCooldown > 0)
            {
                Console.WriteLine("Ability is on cooldown, try again.");
                return ChooseAbility();
            }
            return AbilityList[choice];
        }
    }
}
