using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    public int enemyCount = 1;
    public int xyBounds = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {

    }

    public void GenerateEnemies()
    {

    }
    public void GeneratePickups()
    {

    }
    public Vector3 RandSpawn()
    {
        return new Vector3(Random.Range(-xyBounds, xyBounds), Random.Range(-xyBounds, xyBounds), Random.Range(1, xyBounds));
    }
}
