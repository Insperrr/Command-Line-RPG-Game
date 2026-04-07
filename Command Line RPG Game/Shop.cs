using Command_Line_RPG_Game.Abilities;
using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game
{
    internal class Shop
    {
        public List<Ability> AvailableAbilities { get; set; } = new List<Ability>();

        public void GoToShop(Player player)
        {
            Console.WriteLine("Welcome to the shop!");

            for (int i = 0; i < AvailableAbilities.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {AvailableAbilities[i].Name} - {AvailableAbilities[i].Description}");
            }

            Console.WriteLine("Choose an ability to buy:");

            int choice = int.Parse(Console.ReadLine()) - 1;

            Ability selected = AvailableAbilities[choice];

            player.AbilityList.Add(selected);

            Console.WriteLine($"{selected.Name} added to your abilities!");
        }
    }
}
