using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Panggil SubtractChances() dengan nilai 1 saat objek "Enemy" menyentuh "EndPoint"
            Scoreboard.instance.SubtractChances(1);
            Destroy(other.gameObject); // Hancurkan objek "Enemy"
        }
        else if (other.CompareTag("Friend"))
        {
            // Panggil AddScore() dengan nilai 1 saat objek "Friend" menyentuh "EndPoint"
            Scoreboard.instance.AddScore(1);
            Destroy(other.gameObject); // Hancurkan objek "Friend"
        }
    }
}