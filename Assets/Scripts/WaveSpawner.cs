using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{

    public static int EnemiesAlive = 0;

    public GameManager gameManager;

    public Wave[] waves;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves = 5f;

    private float countdown = 5f;

    [SerializeField]
    private Text waveCountdownTimer;

    private int waveIndex = 0;

    private void Start()
    {
        EnemiesAlive = 0;
    }

    void Update()
    {

        if (EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);

    }

    IEnumerator SpawnWave()
    {

        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        EnemiesAlive = wave.count1;

        for (int i = 0; i < wave.count1; i++)
        {
            SpawnEnemy(wave.enemy1);
            yield return new WaitForSeconds(1f / wave.rate1);
        }

        for (int i = 0; i < wave.count2; i++)
        {
            SpawnEnemy(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate2);
        }

        for (int i = 0; i < wave.count3; i++)
        {
            SpawnEnemy(wave.enemy3);
            yield return new WaitForSeconds(1f / wave.rate3);
        }

        waveIndex++;

    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemy1(GameObject enemy2)
    {
        Instantiate(enemy2, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemy2(GameObject enemy3)
    {
        Instantiate(enemy3, spawnPoint.position, spawnPoint.rotation);
    }
}