using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game
{
    internal class Level
    {
        public int LevelNumber { get; set; }
        public List<Enemy> Enemies { get; set; } = new();
        public int GoldReward { get; set; }
    }
}
