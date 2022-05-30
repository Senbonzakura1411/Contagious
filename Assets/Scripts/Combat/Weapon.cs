using System.Collections;
using Player;
using UnityEngine;

namespace Combat
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected float bulletLifetime; // weapons range
        [SerializeField] protected float reloadTime; // reload time
        [SerializeField] protected float bulletSpeed; // speed of bullet
        [SerializeField] protected int magazineSize; // capacity of ammo
        [SerializeField] protected float timeBetweenShots; // time of shots
        [SerializeField] private string reloadSound;


        [SerializeField] protected BulletControl bullet; // the bullet to create
        [SerializeField] protected Transform firePoint; // the point of instance
        
        protected int currentAmmo; // current amo
        protected float shotCounter; // timer of shots
        protected bool isReloading;
        private PlayerStats playerStats;

        private void Awake() => playerStats = GetComponentInParent<PlayerStats>();

        private void Start() => currentAmmo = magazineSize;
        

        public abstract void Shoot();

        protected IEnumerator Reload()
        {
            AudioManager.Instance.Play(reloadSound);
            isReloading = true;
            yield return new WaitForSeconds(reloadTime * playerStats.GetStat(Stat.PlayerReloadSpeed));
            currentAmmo = magazineSize;
            isReloading = false;
        }
    }
}