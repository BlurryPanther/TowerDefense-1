using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject[] prefabsToSpawn;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private GameObject pointB;

    [Header("State")]
    [SerializeField] private bool isSpawning = true;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (prefabsToSpawn != null && prefabsToSpawn.Length > 0)
            {
                int randomIndex = Random.Range(0, prefabsToSpawn.Length);
                GameObject randomPrefab = prefabsToSpawn[randomIndex];
                GameObject spawnedObject = Instantiate(randomPrefab, transform.position, Quaternion.identity);
                MoveEnemy moveScrpit = spawnedObject.GetComponent<MoveEnemy>();
                if (moveScrpit != null)
                {
                    moveScrpit.SetDestination(pointB.transform.position);
                }
                else Debug.LogWarning("Script Not Asigned");
            }
            else Debug.LogWarning("Empty Spawner");
        }
    }

    public void StopSpawning()
        {
            isSpawning = false;
        }
}