using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.Abilities;
using Command_Line_RPG_Game.Abilities.OffensiveAbilities;
using System.Net.NetworkInformation;

namespace Command_Line_RPG_Game
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}
