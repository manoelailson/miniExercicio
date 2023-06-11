using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyRespawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 5;
    public float respawnTime = 5f;
    public Transform[] spawnPoints;

    private List<GameObject> activeEnemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            if (activeEnemies.Count < maxEnemies)
            {
                Transform spawnPoint = GetRandomSpawnPoint();
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                activeEnemies.Add(enemy);
            }
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            Destroy(enemy,3f);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
    }
}
