using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public int enemyCount = 1;
    public int xyBounds = 12;
    public float time = 0f;
    [SerializeField] GameObject[] enemiesToSpawn;
    [SerializeField] GameObject pickupsToSpawn;
    [SerializeField] float timeTilSpawn;


    void Start()
    {
        StartCoroutine("GenerateEnemies");
    }

    void Update()
    {
        if (!isGameOver) time += Time.deltaTime;
    }
    public void GameOver()
    {
        isGameOver = true;
    }

    IEnumerator GenerateEnemies()
    {
        if (!isGameOver)
        {
            int index = Random.Range(0, enemiesToSpawn.Length);
            Instantiate(enemiesToSpawn[index], RandSpawn(), enemiesToSpawn[index].transform.rotation);
            yield return new WaitForSeconds(timeTilSpawn);
            StartCoroutine("GenerateEnemies");
        }
        yield break;

    }

    //ABSTRACTION
    public Vector3 RandSpawn()
    {
        return new Vector3(Random.Range(-xyBounds, xyBounds), Random.Range(3, xyBounds/2), Random.Range(-xyBounds, xyBounds));

    }
}
