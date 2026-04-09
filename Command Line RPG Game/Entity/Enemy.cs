using Command_Line_RPG_Game.Abilities;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace Command_Line_RPG_Game.Entity
{
    internal abstract class Enemy : Character
    {

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
