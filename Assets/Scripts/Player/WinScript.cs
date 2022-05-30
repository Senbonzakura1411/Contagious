using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    [SerializeField] private float timer = 3f;
    private float currentTimer;

    private void Start()
    {
        currentTimer = timer;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentTimer = timer;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentTimer = timer;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            currentTimer -= Time.deltaTime;
        }
    }

    private void Update()
    {
        if (currentTimer <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
