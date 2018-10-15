using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour 
{
    public static int souls;
    public static int worshippers;

    public int startSouls = 500;
    public int startWorshippers = 10;

    public Text soulsText;
    public Text worshippersText;
    public GameObject gameOver;

    private void Start()
    {
        Time.timeScale = 1;
        gameOver.SetActive(false);

        souls = startSouls;
        worshippers = startWorshippers;

        worshippersText.text = worshippers.ToString();
        soulsText.text = souls.ToString();
    }

    private void Update()
    {
        if(worshippers <= 0)
        {
            GameOver();
        }

        worshippersText.text = worshippers.ToString();
        soulsText.text = souls.ToString();
    }

    void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level_01");
    }
}
