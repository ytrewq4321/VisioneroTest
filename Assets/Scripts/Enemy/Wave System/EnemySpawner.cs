using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] public int enemyCount;

    public void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
