using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemies;

    public Vector2 spawnPosition;
    public float x_range;
    public float y_range;
    float randomX;
    float randomY;
    Vector2 randomV2;

    public float timeToSpawn;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        float tempX = x_range / 2;
        float tempY = y_range / 2;

        randomX = Random.Range(spawnPosition.x - tempX, spawnPosition.x + tempX);
        randomY = Random.Range(spawnPosition.y - tempY, spawnPosition.y + tempY);
        randomV2 = new Vector2(randomX, randomY);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToSpawn)
        {
            float tempX = x_range / 2;
            float tempY = y_range / 2;
            GameObject Enemy = Enemies[Random.Range(0, Enemies.Length)];

            randomX = Random.Range(spawnPosition.x - tempX, spawnPosition.x + tempX + 1);
            randomY = Random.Range(spawnPosition.y - tempY, spawnPosition.y + tempY + 1);
            randomV2 = new Vector2(randomX, randomY);


            Instantiate(Enemy, randomV2, Enemy.transform.rotation);
            timer = 0;
        }
    }
}
