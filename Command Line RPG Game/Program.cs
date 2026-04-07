using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.Abilities;
using Command_Line_RPG_Game.Abilities.OffensiveAbilities;

namespace Command_Line_RPG_Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Username: ");
            Player player = new Player(Console.ReadLine());


            Console.Write("  ____   ___  __  __ __  __    _    _   _ ____  \r\n / ___| / _ \\|  \\/  |  \\/  |  / \\  | \\ | |  _ \\ \r\n| |    | | | | |\\/| | |\\/| | / _ \\ |  \\| | | | |\r\n| |___ | |_| | |  | | |  | |/ ___ \\| |\\  | |_| |\r\n \\____| \\___/|_|  |_|_|  |_/_/   \\_\\_| \\_|____/ \r\n\r\n _     ___ _   _ _____   ____  ____   ____ \r\n| |   |_ _| \\ | | ____| |  _ \\|  _ \\ / ___|\r\n| |    | ||  \\| |  _|   | |_) | |_) | |  _ \r\n| |___ | || |\\  | |___  |  _ <|  __/| |_| |\r\n|_____|___|_| \\_|_____| |_| \\_\\_|    \\____|\n \n \n");
            // Will add error handling later 
            var enemy = new Enemy("Goblin1", 50, 5, 5, [new BasicAttack()]);
            var enemy2 = new Enemy("Goblin2", 30, 2, 10, [new BasicAttack()]);
            BattleSim battleSim = new BattleSim();
            battleSim.StartBattle(player, enemy, enemy2);
        }
    }
}
