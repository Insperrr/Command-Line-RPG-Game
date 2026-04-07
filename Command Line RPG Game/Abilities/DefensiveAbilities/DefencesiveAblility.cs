using Command_Line_RPG_Game.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.Abilities.DefensiveAbilities
{
    internal abstract class DefencesiveAblility : Ability
    {
        public DefencesiveAblility() 
        { 
            AmountOfTargets = 0;
        }
        public override void UseAbility(Character user, Character? target)
        {
            throw new NotImplementedException();
        }
    }
}
