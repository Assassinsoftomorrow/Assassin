using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;

    private void LoseLife()
    {
        if (livesRemaining == 0 )
        {
            return;
        }
        // Decrease the value of lives remaining
        livesRemaining--;
        // Hide one of the lives images
        lives[livesRemaining].enabled = false;

        if (livesRemaining == 0)
        {
            Debug.Log("You Lost");
        }
    }

    private void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            LoseLife();
    }
}
