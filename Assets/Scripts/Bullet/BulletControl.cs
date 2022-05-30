using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed;
    public float range;

    private void Start()
    {
        Destroy(this.gameObject, range); 
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
