using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [Header("lower number more spawn")]
    [SerializeField] private float maxSpawningRate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", maxSpawningRate);
        InvokeRepeating("spawnRateIncrease", 0f, 30f);
    }

    void Spawn()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject gunner = (GameObject)Instantiate(enemy[Random.Range(0,2)]);
        gunner.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        spawnRate();
    }

    private void spawnRate()
    {
        float spawnPerSec;
        if (maxSpawningRate > 1f)
        {
            spawnPerSec = Random.Range(1f, maxSpawningRate);
        }
        else 
        {
            spawnPerSec = 1f;
        }
        Invoke("Spawn", spawnPerSec);
    }

    private void spawnRateIncrease()
    {
        if(maxSpawningRate > 1f)
        {
            maxSpawningRate--;
        }
        if(maxSpawningRate == 1f)
        {
            CancelInvoke("spawnRateIncrease");
        }
    }

}
