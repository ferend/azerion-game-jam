using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private Transform spawnSpot;
    private float time=1;
    private float time2=1;
    public bool canSpawnPowerup;
    public bool freezeenemySpawner;

    private void Start()
    {
        spawnSpot = gameObject.transform;
        SpawnEnemy();
        if (canSpawnPowerup)
        {
            SpawnPowerup();

        }
    }
    private IEnumerator spawner()
    {
        yield return new WaitForSeconds(time);
        SpawnEnemy();
    }
    private IEnumerator powerupspawner()
    {
        yield return new WaitForSeconds(time2);
        SpawnPowerup();
    }
    private void SpawnEnemy()
    {
        if (!PlayerStatusController.Instance.IsAlive())
        {
            DestroyEnemies();
            return;
        }
        if (!freezeenemySpawner)
        {
            time = UnityEngine.Random.Range(1, 4);
            GameObject temp = Instantiate(enemyPrefab,spawnSpot.position, Quaternion.identity);

            enemies.Add(temp);
            StartCoroutine(spawner());
        }
    }
    private void SpawnPowerup()
    {
        if (!PlayerStatusController.Instance.IsAlive())
        {
            DestroyEnemies();
            return;
        }
        if (!freezeenemySpawner)
        {
            time2 = UnityEngine.Random.Range(5, 10);
            Instantiate(powerupPrefab,spawnSpot.position, Quaternion.identity);
            StartCoroutine(powerupspawner());
        }
    }
    public void DestroyEnemies()
    {
        foreach (GameObject temp in enemies)
        {
            Destroy(temp);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
    }
    
    

}
