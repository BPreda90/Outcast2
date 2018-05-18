using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public float velocity;
    public FloatRange timeBetweenSpawns;
    public Stuff[] stuffPrefabs;
    float timeSinceLastSpawn;
    float currentSpawnDelay;
    private void FixedUpdate()
    {
        timeSinceLastSpawn += UnityEngine.Time.deltaTime;
        if(timeSinceLastSpawn>=currentSpawnDelay)
        {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

    void SpawnStuff()
    {
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
        Stuff spawn = Instantiate<Stuff>(prefab);
        spawn.transform.localPosition = transform.position;
        spawn.Body.velocity = transform.up * velocity;
    }
}
