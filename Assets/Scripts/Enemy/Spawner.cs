using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> gameObjects = new ();
    public float timeToSpawn;
    public bool isTimer;
    public bool isRandomized;
    private float currentSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTime = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer)
            UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (currentSpawnTime > 0)
        {
            currentSpawnTime -= Time.deltaTime;
        }
        else
        {
            SpawnObject();
            currentSpawnTime = timeToSpawn;
        }
    }

    public void SpawnObject()
    {
        int index = isRandomized ? Random.Range(0, gameObjects.Count) : 0;
        if(gameObjects.Count>0)
        {
            Instantiate(gameObjects[index], transform.position, gameObjects[index].transform.rotation);
        }
    }    
}
