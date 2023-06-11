using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class respawnerMeteoro : MonoBehaviour
{
   public GameObject[] grupoMeteoro;
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
                Transform spawnPoint = GetRandomAvailableSpawnPoint();

                if (spawnPoint != null)
                {
                    GameObject meteoro = GetRandomMeteoro();
                    GameObject enemy = Instantiate(meteoro, spawnPoint.position, Quaternion.identity);
                    activeEnemies.Add(enemy);
                }
            }
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
            Destroy(enemy,0.3f);
        }
    }

    private Transform GetRandomAvailableSpawnPoint()
    {
        List<Transform> availableSpawnPoints = new List<Transform>();

        foreach (Transform spawnPoint in spawnPoints)
        {
            if (!IsOccupied(spawnPoint))
            {
                availableSpawnPoints.Add(spawnPoint);
            }
        }

        if (availableSpawnPoints.Count > 0)
        {
            int randomIndex = Random.Range(0, availableSpawnPoints.Count);
            return availableSpawnPoints[randomIndex];
        }

        return null;
    }

    private GameObject GetRandomMeteoro()
    {
        int randomIndex = Random.Range(0, grupoMeteoro.Length);
        return grupoMeteoro[randomIndex];
    }

    private bool IsOccupied(Transform spawnPoint)
    {
        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy.transform.position == spawnPoint.position)
            {
                return true;
            }
        }
        return false;
    }
}
