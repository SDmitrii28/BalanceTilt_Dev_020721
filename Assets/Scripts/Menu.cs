using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject[] end;
    public GameObject[] rus;
    public GameObject[] panel;
    public GameObject menu;
    public GameObject priv;
    public AudioSource aud;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        PlayerPrefs.SetInt("p", count);
        PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("language"))
        { 
            if(PlayerPrefs.GetInt("language")==0)
            {
                for(int i = 0; i < end.Length; i++)
                {
                    end[i].SetActive(true);
                    rus[i].SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < end.Length; i++)
                {
                    end[i].SetActive(false);
                    rus[i].SetActive(true);
                }
            }
        }
    }

    public void Play_panel(int k)
    {
        aud.Play();
        switch (k)
        {
            case 0:
            {
                    panel[0].SetActive(true);
                    menu.SetActive(false);
                }
                break;
            case 1:
                {
                    panel[1].SetActive(true);
                    menu.SetActive(false);
                }
                break;
            case 2:
                {
                    panel[2].SetActive(true);
                    menu.SetActive(false);
                }
                break;
            default:
                break;
        }
    }
    public void Close_panel(int k)
    {
        aud.Play();
        switch (k)
        {
            case 0:
                {
                    panel[0].SetActive(false);
                    menu.SetActive(true);
                }
                break;
            case 1:
                {
                    panel[1].SetActive(false);
                    menu.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
    public void Lang(int c)
    {
        aud.Play();
        switch (c)
        {
            case 0:
                {
                    PlayerPrefs.SetInt("language", 0);
                    PlayerPrefs.Save();
                    for (int i = 0; i < end.Length; i++)
                    {
                        end[i].SetActive(true);
                        rus[i].SetActive(false);
                    }
                }
                break;
            case 1:
                {
                    PlayerPrefs.SetInt("language", 1);
                    PlayerPrefs.Save();
                    for (int i = 0; i < end.Length; i++)
                    {
                        end[i].SetActive(false);
                        rus[i].SetActive(true);
                    }
                }
                break;
            default:
                break;
        }
    }
    public void Start_game()
    {
        aud.Play();
        Application.LoadLevel(2);
    }
    public void Privacy()
    {
        aud.Play();
        PlayerPrefs.SetInt("privacy", 1);
        if (PlayerPrefs.HasKey("p"))
        {
            count = PlayerPrefs.GetInt("p");
            count++;
            PlayerPrefs.SetInt("p", count);
        }
        else
        {
            count = 0;
            PlayerPrefs.SetInt("p", count);
        }
        PlayerPrefs.Save();
        priv.SetActive(true);
        panel[1].SetActive(false);

    }
    public void Close_Privacy()
    {
        aud.Play();
        PlayerPrefs.SetInt("privacy", 2);
        PlayerPrefs.Save();
        priv.SetActive(false);
        panel[1].SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
