using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
   public static bool gameOver;
    public GameObject  gameOverPanel;

    public static bool isGamestarted;

    public GameObject startingText;

    public static int numberOfCoins;

   public TextMeshProUGUI  coinsText;
    

    void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGamestarted = false;
        numberOfCoins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        coinsText.text = "Coins: " + numberOfCoins;

        if(Input.GetMouseButtonDown(0)){
            isGamestarted = true;

            Destroy(startingText);
        }
    }
}
