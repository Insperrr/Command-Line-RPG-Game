using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game
{
    internal class BattleSim
    {
        public void battle(Player player, Character target)
        {
            bool firstTurn = getfirstturn(player, target);
            Character current = firstTurn ? player : target;
            Character reciever = firstTurn ? target : player;

            while (player.Health > 0 && target.Health > 0)
            {
                if (current == player)
                {
                    playerturn(player, target);

                }
                else
                {
                    // Simple AI for the target's turn (can be expanded with more complex behavior)
                    Random random = new Random();
                    int abilityIndex = random.Next(0, target.AbilityList.Count);
                    target.AbilityList[abilityIndex].Use(target, player);
                }
                // Swap turns
                Character temp = current;
                current = reciever;
                reciever = temp;
                reportBattleStats(player, target);
       
            }

        }
        public void reportBattleStats(Player player, Character target)
        {
            Console.WriteLine($"{player.Name} - Health: {player.Health}");
            Console.WriteLine($"{target.Name} - Health: {target.Health}");
        }


        public bool getfirstturn(Player player, Character target)
        {
            Random random = new Random();
            int firstturn = random.Next(0, 2);
            if (firstturn == 0)
            {
                Console.WriteLine($"{player.Name} goes first!");
                return true;
            }
            else
            {
                Console.WriteLine($"{target.Name} goes first!");
                return false;
            }
        }

        public void playerturn(Player player, Character target)
        {
            Console.WriteLine("Choose an ability:");
            for (int i = 0; i < player.AbilityList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {player.AbilityList[i].Name}");
            }
            int choice = int.Parse(Console.ReadLine()) - 1;
            if (choice >= 0 && choice < player.AbilityList.Count)
            {
                player.AbilityList[choice].Use(player, target);
            }
            else
            {
                Console.WriteLine("Invalid choice, turn skipped.");
            }
        }
    }
}