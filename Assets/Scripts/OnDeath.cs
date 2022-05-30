using UnityEngine;

public class OnDeath : MonoBehaviour
{
    private Vector3 initialPos;
    private void Awake()
    {
        initialPos = transform.position;
    }

    public void OnDeathEventTriggered()
    {
        transform.position = initialPos;
    }
}
    
