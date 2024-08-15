using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Transform playerTransform;
    private float spawnTime = 15f;
    private float time = 0f;
    [SerializeField] private int enemySpawn = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            for (int i = 0; i < enemySpawn; i++)
            {
                Invoke("Spawnenemy", (float)i);
            }
            time = 0f;
        }
    }

    void Spawnenemy()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }

    public float GetSpawnTime()
    {
        return this.spawnTime;
    }

}
