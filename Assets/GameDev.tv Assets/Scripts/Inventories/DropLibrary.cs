using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameDevTV.Inventories
{
    [CreateAssetMenu(menuName = ("GameDevTV/GameDevTV.UI.InventorySystem/Drop Library"))]
    public class DropLibrary : ScriptableObject
    {
        [SerializeField] private DropConfig[] potentialDrops;
        [SerializeField] private float[] dropChangePercentage;
        // Min and Max unserialized and defaulted to 1 since only dropping one item per enemy
        private int minDrops = 1;
        private int maxDrops = 1;

        [Serializable]
        private class DropConfig
        {
            public InventoryItem item;
            public float relativeChance; 
            // Min and Max hidden and defaulted to 1 since only dropping one item per enemy
            [HideInInspector] public int minNumber;
            [HideInInspector] public int maxNumber;

            public int GetRandomNumber()
            {
                if (!item.IsStackable())
                {
                    return 1;
                }
                var min = minNumber;
                var max = maxNumber;
                return Random.Range(min, max + 1);
            }
        }

        // PUBLIC

        public struct Dropped
        {
            public InventoryItem item;
            public int number;
        }

        public IEnumerable<Dropped> GetRandomDrops(int level)
        {
            if (!ShouldRandomDrop(level))
            {
                yield break;
            }

            for (int i = 0; i < GetRandomNumberOfDrops(); i++)
            {
                yield return GetRandomDrop();
            }
        }

        // PRIVATE
        private bool ShouldRandomDrop(int level)
        {
            var n = Random.Range(0f, 100f);
            return n < GetByLevel(dropChangePercentage, level);
        }

        private int GetRandomNumberOfDrops()
        {
            return Random.Range(minDrops, maxDrops);
        }

        private Dropped GetRandomDrop()
        {
            var randomDrop = SelectRandomItem();
            var drop = new Dropped {item = randomDrop.item, number = randomDrop.GetRandomNumber()};
            return drop;
        }

        private DropConfig SelectRandomItem()
        {
            var totalChance = GetTotalChance();
            var randomRoll = Random.Range(0, totalChance);
            var chanceTotal = 0f;
            foreach (var drop in potentialDrops)
            {
                chanceTotal += drop.relativeChance;
                if (chanceTotal > randomRoll)
                {
                    return drop;
                }
            }

            return null;
        }

        private float GetTotalChance()
        {
            var n = 0f;
            foreach (var drop in potentialDrops)
            {
                n += drop.relativeChance;
            }
            return n;
        }

        private static T GetByLevel<T>(T[] values, int level)
        {
            if (values.Length == 0)
            {
                return default;
            }
            if (level > values.Length)
            {
                return values[^1];
            }

            if (level <= 0)
            {
                return default;
            }

            return values[level - 1];
        }
    }
}