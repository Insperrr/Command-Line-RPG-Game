using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Line_RPG_Game.StatusEffect
{
    internal static class StatusEffectFactory
    {
        // You could load this mapping from JSON
        private static readonly Dictionary<string, Func<StatusEffect>> EffectMap = new()
    {
        { "BasicDefenceBoost", () => new BasicDefenceBoost() }
    };

        public static StatusEffect CreateEffect(string effectId)
        {
            if (!EffectMap.ContainsKey(effectId))
                throw new ArgumentException($"No effect found for id {effectId}");

            return EffectMap[effectId]();
        }
    }
}
