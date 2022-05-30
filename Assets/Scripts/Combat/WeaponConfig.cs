using System.Collections.Generic;
using GameDevTV.Inventories;
using Player;
using UnityEngine;

namespace Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/New weapon", order = 0)]
    public class WeaponConfig : EquipableItem, IModifierProvider
    {
        [SerializeField] private Weapon equippedPrefab = null;
        [SerializeField] private float weaponDamage = 0f;

        // Weapons dont use percentage bonus so it's defaulted to 0
        private readonly float percentageBonus = 0;

        private const string WEAPON_NAME = "Weapon";

        public Weapon Spawn(Transform handTransform)
        {
            DestroyOldWeapon();

            Weapon weapon = null;

            if (equippedPrefab != null)
            {
                weapon = Instantiate(equippedPrefab, handTransform);
                weapon.gameObject.name = WEAPON_NAME;
            }

            return weapon;
        }
        

        private void DestroyOldWeapon()
        {
            var oldWeapon = GameObject.Find(WEAPON_NAME);

            if (oldWeapon == null) return;

            oldWeapon.name = "DESTROYING";
            Destroy(oldWeapon.gameObject);
        }
    
        // PUBLIC
    
        public float GetDamage()
        {
            return weaponDamage;
        }

        public float GetPercentageBonus()
        {
            return percentageBonus;
        }
        

        public IEnumerable<float> GetAdditiveModifiers(Stat stat)
        {
            if (stat == Stat.PlayerDamage)
            {
                yield return weaponDamage;
            }
        }

        public IEnumerable<float> GetPercentageModifiers(Stat stat)
        {
            if (stat == Stat.PlayerDamage)
            {
                yield return percentageBonus;
            }
        }
    }
}
