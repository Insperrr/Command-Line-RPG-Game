using Command_Line_RPG_Game.Entity;
using Command_Line_RPG_Game.Entity.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game
{
    internal static class LevelFactory
    {
        public static Level GetLevel(int levelNumber)
        {
            switch (levelNumber)
            {
                case 1:
                    return new Level
                    {
                        LevelNumber = 1,
                        Enemies = new List<Enemy>
                    {
                        new Goblin(1)
                    },
                        GoldReward = 50
                    };

                case 2:
                    return new Level
                    {
                        LevelNumber = 2,
                        Enemies = new List<Enemy>
                    {
                        new Goblin(1),
                        new Goblin(2)
                    },
                        GoldReward = 100
                    };

                case 3:
                    return new Level
                    {
                        LevelNumber = 3,
                        Enemies = new List<Enemy>
                    {
                        new Goblin(3)
                    },
                        GoldReward = 150
                    };

                default:
                    throw new Exception("Level not defined");
            }
        }
    }
}
