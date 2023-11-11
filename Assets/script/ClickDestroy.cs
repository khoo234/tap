using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickDestroy : MonoBehaviour
{
    public int PointValue;
    void OnMouseDown()
    {
        Destroy(gameObject);
        Scoreboard.instance.AddScore(PointValue);
    }
}