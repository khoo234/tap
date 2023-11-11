using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatasanAkhir : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {

            Scoreboard.instance.SubtractChances(1);
            Destroy(other.gameObject); // Hancurkan objek "Enemy"
        }
        else if (other.CompareTag("Allies"))
        {

            Scoreboard.instance.SubtractChances(0);
            Destroy(other.gameObject); // Hancurkan objek "Friend"
        }
    }
}