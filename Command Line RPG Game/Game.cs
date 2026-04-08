using Command_Line_RPG_Game.Abilities.OffensiveAbilities;
using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game
{
    internal class Game
    {
        private Player player;

        public void Start()
        {
            Console.WriteLine("Welcome to the Command Line RPG Game!");
            Console.WriteLine("Prepare for an epic adventure!\n");
            
            
            init();
            

            //Console.Write("  ____   ___  __  __ __  __    _    _   _ ____  \r\n / ___| / _ \\|  \\/  |  \\/  |  / \\  | \\ | |  _ \\ \r\n| |    | | | | |\\/| | |\\/| | / _ \\ |  \\| | | | |\r\n| |___ | |_| | |  | | |  | |/ ___ \\| |\\  | |_| |\r\n \\____| \\___/|_|  |_|_|  |_/_/   \\_\\_| \\_|____/ \r\n\r\n _     ___ _   _ _____   ____  ____   ____ \r\n| |   |_ _| \\ | | ____| |  _ \\|  _ \\ / ___|\r\n| |    | ||  \\| |  _|   | |_) | |_) | |  _ \r\n| |___ | || |\\  | |___  |  _ <|  __/| |_| |\r\n|_____|___|_| \\_|_____| |_| \\_\\_|    \\____|\n \n \n");
            var enemy = new Enemy("Goblin1", 1, 50, 5, 5, [new BasicAttack()]);
            var enemy2 = new Enemy("Goblin2", 1, 30, 2, 10, [new BasicAttack()]);
            BattleSim battleSim = new BattleSim();
            battleSim.StartBattle(player, enemy, enemy2);
            if (battleSim.Status == BattleStatus.PlayerWon)
            {
                player.Gold += (battleSim.Level * 100);
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
        }

        private void CreatePlayer()
        {
            string name;

            while (true)
            {
                Console.Write("Enter Your Username: ");
                name = Console.ReadLine();

                // Validation checks
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty. Try again.\n");
                    continue;
                }

                if (name.Length < 3)
                {
                    Console.WriteLine("Name must be at least 3 characters long.\n");
                    continue;
                }

                if (name.Length > 15)
                {
                    Console.WriteLine("Name must be 15 characters or less.\n");
                    continue;
                }

                break; 
            }

            player = new Player(name);
        }
    }
}
