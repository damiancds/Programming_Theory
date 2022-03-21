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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GenerateEnemies");
    }

    // Update is called once per frame
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
    public void GeneratePickups()
    {

    }
    public Vector3 RandSpawn()
    {
        return new Vector3(Random.Range(-xyBounds, xyBounds), Random.Range(3, xyBounds/2), Random.Range(-xyBounds, xyBounds));

    }
}
