using System.Collections.Generic;
using UnityEngine;
using Player;


namespace GameDevTV.Inventories
{
    [CreateAssetMenu(menuName = ("GameDevTV/GameDevTV.UI.InventorySystem/Stats Equipable Item"))]
    public class StatsEquipableItem : EquipableItem, IModifierProvider
    {
        [SerializeField] private Modifier[] additiveModifiers;
        [SerializeField] private Modifier[] percentageModifiers;

        [System.Serializable]
        private struct Modifier
        {
            public Stat stat;
            public float value;
        }

        public IEnumerable<float> GetAdditiveModifiers(Stat stat)
        {
            foreach (var modifier in additiveModifiers)
            {
                if (modifier.stat == stat)
                {
                    yield return modifier.value;
                }
            }
        }

        public IEnumerable<float> GetPercentageModifiers(Stat stat)
        {
            foreach (var modifier in percentageModifiers)
            {
                if (modifier.stat == stat)
                {
                    yield return modifier.value;
                }
            }
        }
    }
}