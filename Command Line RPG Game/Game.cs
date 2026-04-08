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
        private Player player;

        public void Start()
        {
            Console.WriteLine("Welcome to the Command Line RPG Game!");
            Console.WriteLine("Prepare for an epic adventure!\n");
            
            
            init();


            //Console.Write("  ____   ___  __  __ __  __    _    _   _ ____  \r\n / ___| / _ \\|  \\/  |  \\/  |  / \\  | \\ | |  _ \\ \r\n| |    | | | | |\\/| | |\\/| | / _ \\ |  \\| | | | |\r\n| |___ | |_| | |  | | |  | |/ ___ \\| |\\  | |_| |\r\n \\____| \\___/|_|  |_|_|  |_/_/   \\_\\_| \\_|____/ \r\n\r\n _     ___ _   _ _____   ____  ____   ____ \r\n| |   |_ _| \\ | | ____| |  _ \\|  _ \\ / ___|\r\n| |    | ||  \\| |  _|   | |_) | |_) | |  _ \r\n| |___ | || |\\  | |___  |  _ <|  __/| |_| |\r\n|_____|___|_| \\_|_____| |_| \\_\\_|    \\____|\n \n \n");
            var enemy = new Goblin(1);
            BattleSim battleSim = new BattleSim();
            battleSim.StartBattle(player, enemy);
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
            player = new Player("Filler Name");
            player.SetName();
        }
    }
}
