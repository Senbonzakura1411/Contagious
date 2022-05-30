using UnityEngine;
using System.Collections.Generic;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/New Player Stats", order = 0)]
    public class BaseStats : ScriptableObject
    {
        [SerializeField] private CharacterStats[] characterStats = null;
        private Dictionary<Stat, float> statsLookUpTable = null;

        


        public float GetStat(Stat stat)
        {
            BuildLookup();
            if (!statsLookUpTable.ContainsKey(stat))
            {
                return 0;
            }

            return statsLookUpTable[stat];
        }

        private void BuildLookup()
        {
            if (statsLookUpTable != null) return;

            statsLookUpTable = new Dictionary<Stat, float>();


            foreach (var characterStat in characterStats)
            {
                statsLookUpTable[characterStat.stat] = characterStat.value;
            }
        }

        [System.Serializable]
        private class CharacterStats
        {
            public Stat stat;
            public float value;
        }
    }
}