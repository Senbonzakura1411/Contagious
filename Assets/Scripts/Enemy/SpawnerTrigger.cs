using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnerToToggle;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject zoneToActivate in spawnerToToggle)
            {
                zoneToActivate.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject zoneToDeactivate in spawnerToToggle)
            {
                zoneToDeactivate.SetActive(false);
            }    
        }
    }
}
