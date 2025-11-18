using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] TriggerEnemySpawn spawnTrigger;

    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1f;

    GameObject[] pool;

    bool canSpawn = false;

    private void Awake()
    {
        PopulatePool();
    }
    void Start()
    {
        spawnTrigger.OnPlayerEntered += StartSpawning;
    }

    void StartSpawning()
    {
        if(!canSpawn)
        {
            canSpawn = true;
            StartCoroutine(SpawnEnemy());
        }
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void EnableObjectsInPool()
    {
        for (int i = 0;i < pool.Length;i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(canSpawn)
        {
            EnableObjectsInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
