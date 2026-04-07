using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.StatusEffect;


namespace Command_Line_RPG_Game.Entity
{
    internal abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Defence { get; set; }
        public int AttackPower { get; set; }
        public int MaxMana { get; set; } = 100;
        public int Mana { get; set; } = 100;
        public int TemporaryDefence { get; set; } = 0;
        public List<Abilities.Ability> AbilityList { get; set; } = new List<Abilities.Ability>();
        public List<StatusEffect.StatusEffect> Effects { get; set; } = new();

        public void UpdateEffects()
        {
            for (int i = Effects.Count - 1; i >= 0; i--)
            {
                Effects[i].Duration--;
                if (Effects[i].Duration <= 0)
                {
                    Effects[i].RemoveEffect(this);
                    Effects.RemoveAt(i);
                }
            }
        }

        public void UpdateAbilities()
        {
            foreach (var ability in AbilityList)
            {
                ability.UpdateCooldown();
            }
        }
    }
}
