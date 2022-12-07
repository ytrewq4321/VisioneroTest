using UnityEngine;

public class Wave : MonoBehaviour
{
    [SerializeField] private int EnemyCount;
    [SerializeField] EnemySpawner[] enemySpawners;
    [SerializeField] private int remainingEnemy=int.MaxValue;

    private void Start()
    {
        GameManager.Instance.EnemyDied.AddListener(UpdateRemainingEnemy);
    }
    public void GenerateWave()
    {
        foreach (var spawn in enemySpawners)
        {
            EnemyCount += spawn.enemyCount;
            spawn.SpawnEnemy();
        }
        remainingEnemy = EnemyCount;
    }

    public bool IsWaveOver()
    {
        return remainingEnemy == 0;
    }

    public void UpdateRemainingEnemy()
    {
        remainingEnemy--;
    } 
}
