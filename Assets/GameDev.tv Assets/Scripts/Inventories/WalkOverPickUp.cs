using UnityEngine;


namespace GameDevTV.Inventories
{
    public class WalkOverPickUp : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var player = GameObject.FindWithTag("Player");
            if (other.gameObject == player)
            {
                GetComponent<Pickup>().PickupItem();
            }
        }
    }
}
