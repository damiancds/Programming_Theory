using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text timeText;
    [SerializeField] Text gameOver;
    GameManager gm;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        gameOver.enabled = false;
        gm = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = Mathf.Round(gm.time).ToString();
        healthText.text = player.health.ToString();
        if (gm.isGameOver) gameOver.enabled = true;
    }
}
