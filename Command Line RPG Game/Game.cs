using Command_Line_RPG_Game.Abilities.OffensiveAbilities;
using Command_Line_RPG_Game.Entity;
using Command_Line_RPG_Game.Entity.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game
{
    internal class Game
    {
        public int Level { get; set; } = 1;
        private Player player;
        private bool HasStarted { get; set; } = false;

        public void Start()
        {
            Console.WriteLine("Welcome to the Command Line RPG Game!");
            Console.WriteLine("Prepare for an epic adventure!\n");
            
            
            
            while (true) 
            {
                GoToMainMenu();
            }
        }

        public void StartNewGame()
        {
            init();
            Console.WriteLine($"Welcome, {player.Name}! Your adventure begins now.\n");
            var enemy = new Goblin(1);
            BattleSim battleSim = new BattleSim();
            battleSim.StartBattle(player, enemy);
        }
        public void GoToMainMenu()
        {
            DisplayMainMenu();
            GetMainMenuInput();
        }
        public void GetMainMenuInput()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Starting new game...");
                    StartNewGame();
                    HasStarted = true;
                    break;

                case "2":
                    if (!HasStarted)
                    {
                        Console.WriteLine("No game to continue.\n");
                        break;
                    }

                    Console.WriteLine("Continuing game...");
                    // ContinueGame(); To Implement later
                    break;

                case "3":
                    Console.WriteLine("Exiting game. Goodbye!");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Start New Game");
            Console.WriteLine("2. Load Game");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
        }

        public void init()
        {
            CreatePlayer();
            HasStarted = true;
        }

        private void CreatePlayer()
        {
            player = new Player("Filler Name");
            player.SetName();
        }
    }
}
