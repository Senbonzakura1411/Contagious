using UnityEngine;

namespace Combat
{
    public class Shotgun : Weapon
    {
        public override void Shoot()
        {
            if (InputManager.GetInstance().playerControls.Controls.Reload.WasPressedThisFrame() && currentAmmo < magazineSize && !isReloading)
            {
                print("reloading");
                StartCoroutine(Reload());
            }
            if (InputManager.GetInstance().playerControls.Controls.Shoot.WasPressedThisFrame() && !isReloading && shotCounter <= 0 ) // can shoot
            {
                print("shooting");
                if (currentAmmo > 0) // have the ammo
                {
                    shotCounter = timeBetweenShots; // restart timer
                    //Create bullets with different angles, counter i manages de angle with 0 and 1 being the center
                    for (int i = -2; i < 3; i++)
                    {
                        Quaternion newAngle = firePoint.rotation * Quaternion.Euler(new Vector3(0, i * 15, 0));
                        var pos = firePoint.position;
                        pos.y = 2.5f;
                        BulletControl newBullet = Instantiate(bullet, pos, newAngle);
                        newBullet.speed = bulletSpeed;
                        newBullet.range = bulletLifetime;
                        AudioManager.Instance.Play("shotgunShot1");
                    }
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