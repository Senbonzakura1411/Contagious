using System.Collections;
using UnityEngine;

namespace Combat
{
    public class Rifle : Weapon
    {
        [Range(0.09f, 0.01f)] [SerializeField] private float timeBetweenEachBullet;

        public override void Shoot()
        {
            if (InputManager.GetInstance().playerControls.Controls.Reload.WasPressedThisFrame() && currentAmmo < magazineSize && !isReloading)
            {
                print("reloading");
                StartCoroutine(Reload());
            }

            if (InputManager.GetInstance().playerControls.Controls.Shoot.WasPressedThisFrame() && !isReloading &&
                shotCounter <= 0) // can shoot
            {
                if (currentAmmo > 0) // have the ammo
                {
                    shotCounter = timeBetweenShots; // restart timer
                    //Create 3
                    StartCoroutine(ShootBullets());
                }
                else
                {
                    StartCoroutine(Reload());
                }
            }
            else
            {
                shotCounter -= Time.deltaTime;
            }
        }


        private IEnumerator ShootBullets()
        {
            var pos = firePoint.position;
            pos.y = 2.5f;
            BulletControl newBullet = Instantiate(bullet, pos, firePoint.rotation);
            newBullet.speed = bulletSpeed;
            newBullet.range = bulletLifetime;
            AudioManager.Instance.Play("rifleShot1");
            currentAmmo -= 1;
            yield return new WaitForSeconds(timeBetweenEachBullet);
            BulletControl newBullet2 = Instantiate(bullet, pos, firePoint.rotation);
            newBullet2.speed = bulletSpeed;
            newBullet2.range = bulletLifetime;
            AudioManager.Instance.Play("rifleShot1");
            currentAmmo -= 1;
            yield return new WaitForSeconds(timeBetweenEachBullet);
            BulletControl newBullet3 = Instantiate(bullet, pos, firePoint.rotation);
            newBullet3.speed = bulletSpeed;
            newBullet3.range = bulletLifetime;
            AudioManager.Instance.Play("rifleShot1");
            currentAmmo -= 1;
        }
    }
}