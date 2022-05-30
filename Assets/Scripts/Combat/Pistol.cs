using UnityEngine;

namespace Combat
{
    public class Pistol : Weapon
    {
        public override void Shoot()
        {
            if (InputManager.GetInstance().playerControls.Controls.Reload.WasPressedThisFrame() && currentAmmo < magazineSize && !isReloading)
            {
                print("reloading");
                StartCoroutine(Reload());
            }
            if (InputManager.GetInstance().playerControls.Controls.Shoot.WasPressedThisFrame() && !isReloading && shotCounter <= 0) // can shoot
            {
                print("shooting");
                if (currentAmmo > 0) // have the ammo
                {
                    shotCounter = timeBetweenShots; // restart timer
                    var pos = firePoint.position;
                    pos.y = 2.5f;
                    BulletControl newBullet = Instantiate(bullet, pos, firePoint.rotation);
                    newBullet.speed = bulletSpeed;
                    newBullet.range = bulletLifetime;
                    AudioManager.Instance.Play("gunShot1");
                    currentAmmo -= 1;
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
    }
    
    
}
