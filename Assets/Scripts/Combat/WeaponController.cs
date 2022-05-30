using GameDevTV.Inventories;
using GameDevTV.Utils;
using UnityEngine;

namespace Combat
{
    public class WeaponController : MonoBehaviour
    {
        
        [SerializeField] private WeaponConfig defaultWeapon;
        [SerializeField] Transform rightHandTransform;


        private Equipment equipment;
        // private WeaponConfig currentWeaponConfig;
        LazyValue<Weapon> currentWeapon;

        // LIFECYCLE METHODS
        private void Awake()
        {
            //currentWeaponConfig = defaultWeapon;
            currentWeapon = new LazyValue<Weapon>(SetupDefaultWeapon);
            equipment = GetComponent<Equipment>();
            if (equipment)
            {
                equipment.EquipmentUpdated += UpdateWeapon;
            }
        }

        private void Start()
        {
            currentWeapon.ForceInit();
        }

        private void Update()
        {
            currentWeapon.value.Shoot();
        }

        // PRIVATE
        private void EquipWeapon(WeaponConfig weapon)
        {
            //currentWeaponConfig = weapon;
            currentWeapon.value = AttachWeapon(weapon);
        }

        private Weapon SetupDefaultWeapon()
        {
            return AttachWeapon(defaultWeapon);
        }

        private Weapon AttachWeapon(WeaponConfig weapon)
        {
            return weapon.Spawn(rightHandTransform);
        }

        private void UpdateWeapon()
        {
            var weapon = equipment.GetItemInSlot(EquipLocation.Weapon) as WeaponConfig;
            if (weapon == null)
            {
                EquipWeapon(defaultWeapon);
            }
            else
            {
                EquipWeapon(weapon);
            }
        }
    }
}