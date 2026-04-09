using Command_Line_RPG_Game.Entity;
using Command_Line_RPG_Game.StatusEffect;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;

namespace Command_Line_RPG_Game.Abilities
{
    enum RarityLevel
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary
    }
    internal abstract class Ability
    {
        public virtual string Name => Regex.Replace(GetType().Name, "(\\B[A-Z])", " $1");
        public virtual int Cooldown { get; set; } = 0;
        public int CurrentCooldown { get; set; } = 0;
        public int ManaCost { get; set; } = 0;
        public int AmountOfTargets { get; set; } = 1;
        public RarityLevel Rarity { get; set; } = RarityLevel.Common;
        public string EffectId { get; set; }
        public string AbilityDescription { get; set; } = "No description";

        public StatusEffect.StatusEffect? GetEffect()
        {
            if (EffectId == null) return null;
            return StatusEffectFactory.CreateEffect(EffectId);
        }
        public virtual string Description
        {
            get
            {
                var effect = GetEffect();
                string abilityDescription = effect != null ? effect.GetDescription() : AbilityDescription;
                string fullstring = Cooldown == 0 ? $"{Name}: {abilityDescription} - No Cooldown" : 
                    $"{Name}: {abilityDescription} - Cooldown: {CurrentCooldown}/{Cooldown}";
                fullstring += ManaCost > 0 ? $" - Mana Cost: {ManaCost}" : "";
                return fullstring;
            }
        }
        public void ApplyCooldown()
        {
            CurrentCooldown = Cooldown;
        }
        public void DeductMana(Character user)
        {
            user.Mana -= ManaCost;
            if (user.Mana < 0) user.Mana = 0;
        }
        public abstract void UseAbility(Character user, Character? target);
        public bool Use(Character user, Character? target = null)
        {
            if (!CheckConditionsValid(user))
            {
                return false;
            }
            ApplyCooldown();
            DeductMana(user);
            UseAbility(user, target);
            return true;
        }

        private bool CheckConditionsValid(Character user)
        {
            if (CurrentCooldown > 0)
            {
                Console.WriteLine($"{Name} is on cooldown for {CurrentCooldown} more turns.");
                return false;
            }
            else if (user.Mana < ManaCost)
            {
                Console.WriteLine($"{user.Name} does not have enough mana to use {Name}.");
                return false;
            }
            return true;
        }

        public void UpdateCooldown()
        {
            if (CurrentCooldown > 0)
            {
                CurrentCooldown--;
            }
        }
    }
}