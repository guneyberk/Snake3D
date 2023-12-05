using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject _enemySpawnPoints;
    public static int enemyCount=0;
    bool _newRound=true;

    int _enemySpawnCount = 0;
    private void Start()
    {
        InvokeRepeating("NewRound",5f,0.1f);
    }
    private void NewRound()
    {
        if (enemyCount<=0)
        {
            _enemySpawnCount += 10;
            enemyCount =_enemySpawnCount;
            EnemySpawn(_enemySpawnCount);
        }
    }
    public void EnemySpawn(int localenemyCount)
    {

        for (int i = 0; i < localenemyCount; i++)
        {

            GameObject enemy = ObjectPool.Instance.SpawnEnemies();
            if (enemy != null)
            {
                
                enemy.SetActive(true);
                enemy.transform.position = _enemySpawnPoints.transform.GetChild(Random.Range(0, _enemySpawnPoints.transform.childCount)).transform.position;
            }

        }
    }
   

}
