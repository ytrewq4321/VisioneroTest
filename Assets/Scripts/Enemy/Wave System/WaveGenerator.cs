using System.Collections;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private Wave[] waves;
    [SerializeField] private float timeBetweenWave;
    private int currentWave=0;

    void Start()
    {
        StartCoroutine(Ñooldown());
    }

    private void Update()
    {
        if (IsAllWaveOver())
            GameManager.Instance.WinGame.Invoke();

        if (waves[currentWave].IsWaveOver() && currentWave < waves.Length - 1)
        {
            currentWave++;
            StartCoroutine(Ñooldown());            
        }
    }

    private IEnumerator Ñooldown()
    {
        yield return new WaitForSeconds(timeBetweenWave);
        waves[currentWave].GenerateWave();
    }

    public bool IsAllWaveOver()
    {
        return waves[^1].IsWaveOver();
    }
}
