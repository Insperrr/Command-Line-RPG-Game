using Command_Line_RPG_Game.Abilities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Command_Line_RPG_Game.Entity
{
    internal abstract class Enemy : Character
    {
        public int Level { get; protected set; }

        protected Enemy(int level)
        {
            Level = level;
            InitializeStats();
            InitializeAbilities();
        }

        protected abstract void InitializeStats();
        protected abstract void InitializeAbilities();
    }
}
