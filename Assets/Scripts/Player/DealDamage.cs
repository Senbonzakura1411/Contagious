using UnityEngine;

namespace Player
{
    public class DealDamage : MonoBehaviour
    {
        [SerializeField] private float damage;
        public void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<Health>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        
    }
}
