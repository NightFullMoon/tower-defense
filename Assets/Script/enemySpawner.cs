using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public static int EnemyAliveCont = 0;
    public Wave[] waves;

    public Transform start;

    public float waveRate = 3;

    private Coroutine coroutine;


    void Start()
    {
        coroutine =  StartCoroutine(SpawnEnemy());
    }

    public void stop() {
        StopCoroutine(coroutine);
    }

    IEnumerator SpawnEnemy()
    {
        foreach (Wave wave in waves)
        {
            for (int i = 0; i < wave.count; ++i)
            {
                GameObject.Instantiate(wave.enemyPrefab, start.position, Quaternion.identity);
                ++EnemyAliveCont;
                if (i != wave.count - 1)
                {
                    yield return new WaitForSeconds(wave.rate);
                }

            }

            while (0 < EnemyAliveCont)
            {
                yield return 0;

            }
            yield return new WaitForSeconds(waveRate);

        }
    }
}
