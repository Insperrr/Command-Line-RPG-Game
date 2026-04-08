using System;
using System.Collections.Generic;
using System.Text;
using Command_Line_RPG_Game.StatusEffect;


namespace Command_Line_RPG_Game.Entity
{
    internal abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; set; }
        public int Defence { get; set; }
        public int AttackPower { get; set; }
        public int MaxMana { get; set; } = 100;
        public int Mana { get; set; } = 100;
        public int TemporaryDefence { get; set; } = 0;
        public int Level { get; set; } = 1;
        public List<Abilities.Ability> AbilityList { get; set; } = new List<Abilities.Ability>();
        public List<StatusEffect.StatusEffect> Effects { get; set; } = new();
        public event Action OnTurnStart;
        public void StartTurn()
        {
            OnTurnStart?.Invoke(); 
        }
       

        public void ApplyStatusEffect(StatusEffect.StatusEffect effect)
        {
            effect.ApplyEffect(this);
            Effects.Add(effect); 
        }

        public void AddAbility(Abilities.Ability ability)
        {
            AbilityList.Add(ability);
            OnTurnStart += ability.UpdateCooldown;
        }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }
    }
}
