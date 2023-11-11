using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; // Variabel untuk menyimpan nilai skor.

    public int GetScore()
    {
        return score; // Metode untuk mendapatkan nilai skor.
    }

    public void AddScore(int amount)
    {
        score += amount; // Metode untuk menambahkan poin ke skor.
    }
}
