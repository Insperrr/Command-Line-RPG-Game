using Command_Line_RPG_Game.Abilities;
using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Command_Line_RPG_Game
{
    internal class BattleSim
    {
        public void StartBattle(Player player, params Character[] participants)
        {
            if (participants.Length < 1)
            {
                Console.WriteLine("Battle requires at least 2 participants!");
                return;
            }

            // Create array with player and all participants
            Character[] allParticipants = new Character[participants.Length + 1];
            allParticipants[0] = player;
            Array.Copy(participants, 0, allParticipants, 1, participants.Length);

            // Display battle start
            Console.WriteLine($"A wild battle begins!");
            Console.WriteLine($"Battle Start: {player.Name} vs " + string.Join(", ", participants.Select(p => p.Name)));
            Console.WriteLine("\n");

            BattleLoop(allParticipants);

        }

        public void BattleLoop(Character[] allParticipants)
        {
            // Generate randomized turn order
            List<int> turnOrder = GenerateRandomTurnOrder(allParticipants.Length);
            int turnIndex = 0;

            Player player = (Player)allParticipants[0]; // Assuming player is always the first participant

            while (allParticipants.Count(p => p.Health > 0) > 1)
            {
                // Get next participant in turn order
                int currentParticipantIndex = turnOrder[turnIndex % turnOrder.Count];
                Character currentParticipant = allParticipants[currentParticipantIndex];

                // Skip if participant is dead
                if (currentParticipant.Health <= 0)
                {
                    turnIndex++;
                    continue;
                }

                reportBattleStats(allParticipants);

                // Determine if it's the player's turn
                if (currentParticipant == player)
                {
                    playerturn(player, allParticipants);
                }
                else
                {
                    enemyturn((Character)currentParticipant, player, allParticipants);
                }

                turnIndex++;
            }
        }



        private List<int> GenerateRandomTurnOrder(int participantCount)
        {
            Random random = new Random();
            List<int> turnOrder = new List<int>();
            for (int i = 0; i < participantCount; i++)
            {
                turnOrder.Add(i);
            }
            // Shuffle the turn order
            for (int i = turnOrder.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);
                int temp = turnOrder[i];
                turnOrder[i] = turnOrder[randomIndex];
                turnOrder[randomIndex] = temp;
            }
            return turnOrder;
        }

        public void reportBattleStats(Character[] allParticipants)
        {
            Console.WriteLine("-----------------------\nBattle Stats: \n" +
                "-----------------------");
            foreach (Character participant in allParticipants)
            {
                string status = participant.Health > 0 ? "Alive" : "Dead";
                Console.WriteLine($"{participant.Name} - Health: {participant.Health}/{participant.MaxHealth} ({status})");
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine("\n ");
        }

        public Character ChooseTarget(Character user, Character[] allParticipants)
        {
            Console.WriteLine("Choose a target:");
            List<Character> aliveEnemies = allParticipants.Where(p => p != user && p.Health > 0).ToList();
            for (int i = 0; i < aliveEnemies.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {aliveEnemies[i].Name}");
            }
            int targetChoice = int.Parse(Console.ReadLine()) - 1;
            if (targetChoice >= 0 && targetChoice < aliveEnemies.Count)
            {
                // Return the chosen target
                return aliveEnemies[targetChoice];
            }
            else
            {
                Console.WriteLine("Invalid choice, turn skipped.");
                return null;
            }
        }

        public void playerturn(Player player, Character[] allParticipants)
        {
            player.UpdateEffects();
            bool validAttack = false;
            Ability chosenAbility = player.ChooseAbility();
            Character chosenTarget = ChooseTarget(player, allParticipants);
            if (chosenAbility != null && chosenTarget != null)
            {
                chosenAbility.Use(player, chosenTarget);
            }
            else
            {
                Console.WriteLine("Invalid choice, turn skipped.");
            }
        }

        public void enemyturn(Character enemy, Player player, Character[] allParticipants)
        {
            Console.WriteLine($"{enemy.Name}'s Turn!");
            // Simple AI for the enemy's turn
            Random random = new Random();
            int abilityIndex = random.Next(0, enemy.AbilityList.Count);
            
            // Choose a random alive target that isn't itself
            List<Character> possibleTargets = allParticipants.Where(p => p != enemy && p.Health > 0).ToList();
            if (possibleTargets.Count == 0) return;

            Character target = possibleTargets[random.Next(possibleTargets.Count)];
            if (!enemy.AbilityList[abilityIndex].Use(enemy, target))
            {
                Console.WriteLine("Enemy's attack missed!");
            }
        }
    }
}