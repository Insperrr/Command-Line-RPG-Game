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

            // Will add error handling later 
            Player player = new Player(Console.ReadLine());
            var enemy = new Enemy("Goblin", 50, 5, 5, [new BasicAttack()]);
            BattleSim battleSim = new BattleSim();
            battleSim.battle(player, enemy);
        }
    }
}
