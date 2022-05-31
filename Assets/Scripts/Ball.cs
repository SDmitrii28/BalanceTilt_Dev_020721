using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("red"))
        {
            aud.Play();
            Game.count_red++;
            PlayerPrefs.SetInt("red", Game.count_red);
            PlayerPrefs.Save();
            if (Game.count_red < 3)
            {
                Application.LoadLevel(2);
            }
        }
        if (collision.collider.CompareTag("blue"))
        {
            aud.Play();
            Game.count_blue++;
            PlayerPrefs.SetInt("blue", Game.count_blue);
            PlayerPrefs.Save();
            if (Game.count_blue < 3)
            {
                Application.LoadLevel(2);
            }

        }
    }
}
