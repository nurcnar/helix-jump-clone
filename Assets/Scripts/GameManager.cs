using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        instance = this;
    }
    bool isGameOver;
    public Text scoreText;
    private int m_score;
    public int Score
    {
        get => m_score;
        set
        {
            m_score = value;
            scoreText.text = value.ToString();
        }
    }
    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        if (Score > PlayerPrefs.GetInt("highScore"))
        {
            print("eski en yüksek skor: " + PlayerPrefs.GetInt("highScore").ToString() + "yeni en yüksek skor: " + Score);
            PlayerPrefs.SetInt("highScore", Score);
        }
        StartCoroutine(waitAndFinish());
        IEnumerator waitAndFinish()
        {
            FindObjectOfType<BallMovement>().enabled = false;
            FindObjectOfType<BallMovement>().GetComponent<Rigidbody>().isKinematic = true;
            FindObjectOfType<RotatePlatform>().enabled = false;
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(0);
        }
    }
}
