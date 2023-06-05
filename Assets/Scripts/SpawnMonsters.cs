using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnMonsters : MonoBehaviour
{
    public int smallCount;
    public int mediumCount;
    public int largeCount;
    public GameObject smallEn;
    public GameObject mediumEn;
    public GameObject largeEn;
    public float interval;
    public Transform spawnPoint;
    public MoneyBank Base;
    float Difficulty = 0;
    float lastSpawned;
    int wave = 0;
    int score;
    public WaveCounter waveCounter;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnWave", 2, interval);
        lastSpawned = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastSpawned > interval)
        {
            lastSpawned = Time.time;
            SpawnWave();
        }
    }
    void SpawnWave()
    {
        if (interval > 3)
        {
            interval = (float)(interval - interval * 0.04 * (0.5 / (Difficulty + 0.1)));
            if (interval < 3)
                interval= 3;
        }
        wave++;
        score += wave;
        scoreText.text = score.ToString();
        waveCounter.CountUpdate(wave);
        for (int i = 0; i < SpawnAmount(mediumCount); i++)
        {
            GameObject grunt = Instantiate(mediumEn, spawnPoint.position, Quaternion.identity);
            grunt.GetComponent<Enemy>().Base = Base;
            grunt.GetComponent<Enemy>().difficult = Difficulty;
        }
        for (int i = 0; i < SpawnAmount(smallCount); i++)
        {
            GameObject lich = Instantiate(smallEn, spawnPoint.position, Quaternion.identity);
            lich.GetComponent<Enemy>().Base = Base;
            lich.GetComponent<Enemy>().difficult = Difficulty;
        }
        for (int i = 0; i < SpawnAmount(largeCount); i++)
        {
            GameObject golem = Instantiate(largeEn, spawnPoint.position, Quaternion.identity);
            golem.GetComponent<Enemy>().Base = Base;
            golem.GetComponent<Enemy>().difficult = Difficulty;
        }
        Debug.Log(Difficulty.ToString() + ", " + interval.ToString() + ", " + SpawnAmount(mediumCount).ToString());
        Difficulty += (float)0.1;
    }

    int SpawnAmount(int Count)
    {
        return (int)(Count - 2 + Difficulty * Count);
    }
    public int GetScore()
    {
        return score;
    }
    public int GetWave()
    {
        return wave;
    }
}
