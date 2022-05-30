using UnityEngine;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private BaseStats baseStats;
        [SerializeField] private bool shouldUseModifiers;
        
        
        // PUBLIC
        public float GetStat (Stat stat)
        {
            return (GetBaseStat(stat) + GetAdditiveModifier(stat)) * (1 + GetPercentageModifier(stat)/100);
        }


        private float GetBaseStat(Stat stat)
        {
            return baseStats.GetStat(stat);
        }
        
        // PRIVATE
        private float GetAdditiveModifier(Stat stat)
        {
            if (!shouldUseModifiers) return 0f;
        
            var total = 0f;
            foreach (IModifierProvider provider in GetComponents<IModifierProvider>())
            {
                foreach (float modifier in provider.GetAdditiveModifiers(stat))
                {
                    total += modifier;
                }
            }
            return total;
        }
        private float GetPercentageModifier(Stat stat)
        {
            if (!shouldUseModifiers) return 0;

            var total = 0f;
            foreach (IModifierProvider provider in GetComponents<IModifierProvider>())
            {
                foreach (float modifier in provider.GetPercentageModifiers(stat))
                {
                    total += modifier;
                }
            }
            return total;
        }
    }
}