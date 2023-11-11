using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private bool isDead;
    public GameManagerScript gameManager;
    public static Scoreboard instance;
    private int score = 0;
    private int chances = 3; // Jumlah kesempatan gagal

    public Text scoreText;
    public Text chancesText; // Text untuk menampilkan kesempatan gagal

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        score = 0;
        chances = 3; // Atur jumlah kesempatan gagal awal
        UpdateScoreText();
        UpdateChancesText();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void SubtractChances(int value)
    {
        chances -= value;
        UpdateChancesText();

        if (chances <= 0 && !isDead)
        {
            // Jika kesempatan habis, lakukan sesuatu, misalnya memanggil fungsi GameOver()
            GameOver();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = $" Score : {score}";
    }

    void UpdateChancesText()
    {
        if (chancesText != null)
            chancesText.text = $"Lives : {chances}";
    }

    // Fungsi untuk memanggil saat kesempatan habis
    void GameOver()
    {
        // Lakukan sesuatu, misalnya mengakhiri permainan atau mereset level
        isDead = true;
        gameManager.gameover();
        Debug.Log("Game Over");
        Application.Quit();
    }
}