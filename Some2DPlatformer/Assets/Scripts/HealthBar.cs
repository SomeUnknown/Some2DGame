using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int health;
    public int numberOfLives;
    public Image[] lives;
    public Sprite fullLives;
    public Sprite emptyLives;

    // Update is called once per frame
    void Update()
    {
        if (health > numberOfLives)
        {
            health = numberOfLives;
        }

        for (int i = 0; i < lives.Length; i++)
        {
            if (i < health)
            {
                lives[i].sprite = fullLives;
            }
            else
            {
                lives[i].sprite = emptyLives;
            }
        }
    }
}
