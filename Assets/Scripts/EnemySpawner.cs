using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemySpawnPoints;

    IEnumerator WaitStart()
    {
        yield return new WaitForSeconds(2f);
    }
    IEnumerator Start()
    {
        StartCoroutine(EnemySpawn());
        yield return null;

    }
    IEnumerator EnemySpawn()
    {

        for (int i = 0; i < 10; i++)
        {

            GameObject enemy = ObjectPool.Instance.SpawnEnemies();
            if (enemy != null)
            {
                enemy.SetActive(true);
                enemy.transform.position = _enemySpawnPoints.transform.GetChild(Random.Range(0, _enemySpawnPoints.transform.childCount)).transform.position;
            }
            yield return new WaitForSeconds(0.1f);

        }
    }
}
