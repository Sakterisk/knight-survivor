using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnRate = .02f;
    public float spawnRadius = 5f;
    public int offsetHor = 15;
    public int offsetVer = 10;
    public int maxEnemies = 80;
    private float multiplier = 1f;
    private GameObject player;
    private int enemyIndex = 0;
    private List<GameObject> currentEnemies;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentEnemies = new List<GameObject>();
        StartCoroutine(Spawning());
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            if (currentEnemies.Count < maxEnemies)
            {
                GameObject spawned = Instantiate(enemyPrefabs[enemyIndex], RandomPosition(), Quaternion.identity);
                currentEnemies.Add(spawned);
                spawned.GetComponent<Enemy>().Initiate(this, player, multiplier);
            }
        }
    }

    private Vector3 RandomPosition()
    {
        int side = Random.Range(0, 4);
        float horizontal;
        float vertical;
        if (side == 0 || side == 1) // top and bottom side
        {
            horizontal = Random.Range((float)-offsetHor, offsetHor);
        }
        else if (side == 2) // left side
        {
            horizontal = Random.Range(-spawnRadius - offsetHor, -offsetHor);
        }
        else // right side
        {
            horizontal = Random.Range(offsetHor, offsetHor + spawnRadius);
        }
        if (side == 2 || side == 3) // left and right side
        {
            vertical = Random.Range(-spawnRadius - offsetVer, spawnRadius + offsetVer);
        }
        else if (side == 0) // top side
        {
            vertical = Random.Range(offsetVer, spawnRadius + offsetVer);
        }
        else // bottom side
        {
            vertical = Random.Range(-spawnRadius - offsetVer, -offsetVer);
        }
        return new Vector3(transform.position.x + horizontal, transform.position.y + vertical, 0);
    }

    private void Update()
    {
        for (int i = 0; i < currentEnemies.Count; i++)
        {
            Vector3 distance = currentEnemies[i].transform.position - player.transform.position;
            if (Mathf.Abs(distance.x) > offsetHor + spawnRadius)
            {
                Destroy(currentEnemies[i]);
                currentEnemies.RemoveAt(i);
            }
            else if (Mathf.Abs(distance.y) > offsetVer + spawnRadius)
            {
                Destroy(currentEnemies[i]);
                currentEnemies.RemoveAt(i);
            }
        }
    }

    internal void RemoveEnemy(GameObject gameObject)
    {
        currentEnemies.Remove(gameObject);
    }

    internal GameObject GetClosestEnemy()
    {
        GameObject closest = null;
        float minDistance = float.MaxValue;
        for (int i = 0; i < currentEnemies.Count; i++)
        {
            float distance = currentEnemies[i].GetComponent<Enemy>().GetDistanceToPlayer();
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = currentEnemies[i];
            }
        }
        return closest;
    }

    internal void AddToMultiplier(float amount)
    {
        multiplier += amount;
    }

    internal void NextEnemy()
    {
        if (enemyIndex < enemyPrefabs.Length - 1)
        {
            enemyIndex++;
        }
        else
        {
            enemyIndex = 0;
        }
    }

    internal void IncreaseNumberOfEnemies(int amount)
    {
        maxEnemies += amount;
    }
}
