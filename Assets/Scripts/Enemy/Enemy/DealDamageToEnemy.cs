using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToEnemy : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
