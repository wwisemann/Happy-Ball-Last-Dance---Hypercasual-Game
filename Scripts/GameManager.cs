using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public GameObject loseUI;
    public GameObject winUI;
    private int score = 0;
    public Text loseScoreText,winScoreText;
    public Text gameInScoreText;
    public AudioSource coinSound;

    void Start()
    {

    }

    public void LevelEnd()
    { 
        loseUI.SetActive(true);
        loseScoreText.text = "Toplam Puan: " + score;
        gameInScoreText.gameObject.SetActive(false);
    }

    public void WinLevel()
    {
        winUI.SetActive(true);
        winScoreText.text = "Toplam Puan: " + score;
        gameInScoreText.gameObject.SetActive(false);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartApp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
 
    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        coinSound.Play();
        gameInScoreText.text = "Skor: " + score.ToString();
    }

  
}