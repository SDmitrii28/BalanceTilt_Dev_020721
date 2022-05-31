using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public GameObject[] end;
    public GameObject[] rus;
    public AudioSource aud;
    public GameObject ob_red;
    public GameObject ob_blue;
    private Vector2 ver_red;
    private Vector2 ver_blue;
    public static int count_red;
    public static int count_blue;
    private int count_red1;
    private int count_blue1;
    public Button btn_red;
    public Button btn_blue;
    public Image[] ball_red;
    public Image[] ball_blue;
    public GameObject ball_r;
    public GameObject ball_b;
    public GameObject pn;
    public Text tx;
    public AudioSource aud1;
    public AudioSource aud2;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("red"))
        {
            count_red = PlayerPrefs.GetInt("red");
        }
        else
        {
            count_red = 0;
            count_red1 = 0;
        }

        if (PlayerPrefs.HasKey("blue"))
        {
            count_blue = PlayerPrefs.GetInt("blue");
        }
        else
        {
            count_blue = 0;
            count_blue1 = 0;
        }

        Debug.Log("count_red" + count_red.ToString());
        Debug.Log("count_blue" + count_blue.ToString());
        ver_red = new Vector2(ob_red.transform.position.x, ob_red.transform.position.y);
        ver_blue = new Vector2(ob_blue.transform.position.x, ob_blue.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        ob_red.transform.position = Vector2.Lerp(ob_red.transform.position, ver_red, 5 * Time.deltaTime);
        ob_blue.transform.position = Vector2.Lerp(ob_blue.transform.position, ver_blue, 5 * Time.deltaTime);
        if (count_red1 == 4)
        {
            btn_red.interactable = false;
        }
        if (count_blue1 == 4)
        {
            btn_blue.interactable = false;
        }
        if (count_red == 0)
        {
            ball_red[0].color=new Color(255f, 255f, 255f, 0.3f);
            ball_red[1].color = new Color(255f, 255f, 255f, 0.3f);
            ball_red[2].color = new Color(255f, 255f, 255f, 0.3f);
        }
        if (count_red == 1)
        {
            ball_red[0].color = new Color(255f, 255f, 255f, 255f);
            ball_red[1].color = new Color(255f, 255f, 255f, 0.3f);
            ball_red[2].color = new Color(255f, 255f, 255f, 0.3f);
        }
        if (count_red == 2)
        {
            ball_red[0].color = new Color(255f, 255f, 255f, 255f);
            ball_red[1].color = new Color(255f, 255f, 255f, 255f);
            ball_red[2].color = new Color(255f, 255f, 255f, 0.3f);
        }
        if (count_red == 3)
        {
            ball_red[0].color = new Color(255f, 255f, 255f, 255f);
            ball_red[1].color = new Color(255f, 255f, 255f, 255f);
            ball_red[2].color = new Color(255f, 255f, 255f, 255f);
        }

        ////
        if (count_blue == 0)
        {
            ball_blue[0].color = new Color(255f, 255f, 255f, 0.3f);
            ball_blue[1].color = new Color(255f, 255f, 255f, 0.3f);
            ball_blue[2].color = new Color(255f, 255f, 255f, 0.3f);
        }
        if (count_blue == 1)
        {
            ball_blue[0].color=new Color(255f,255f,255f,255f);
            ball_blue[1].color = new Color(255f, 255f, 255f, 0.3f);
            ball_blue[2].color = new Color(255f, 255f, 255f, 0.3f);
        }
        if (count_blue == 2)
        {
            ball_blue[0].color = new Color(255f, 255f, 255f, 255f);
            ball_blue[1].color = new Color(255f, 255f, 255f, 255f);
            ball_blue[2].color = new Color(255f, 255f, 255f, 0.3f);
        }
        if (count_blue == 3)
        {
            ball_blue[0].color = new Color(255f, 255f, 255f, 255f);
            ball_blue[1].color = new Color(255f, 255f, 255f, 255f);
            ball_blue[2].color = new Color(255f, 255f, 255f, 255f);
        }
        Game_over_red();
        Game_over_blue();
        Game_over_draw();
    }
    public void Restart_game()
    {
        Time.timeScale = 1f;
        aud.Play();
        Application.LoadLevel(2);
    }
    public void In_menu()
    {
        aud1.Play();
        Time.timeScale = 1f;
        aud.Play();
        Application.LoadLevel(1);

    }
public void Game_over_red()
{
    if (count_red == 3)
    {
        aud2.Play();
        ball_r.SetActive(false);
        ball_b.SetActive(false);
        pn.SetActive(true);

        Time.timeScale = 0f;
        count_red = 0;
        count_blue = 0;
        PlayerPrefs.SetInt("red", count_red);
        PlayerPrefs.SetInt("blue", count_blue);
        PlayerPrefs.Save();
        if (PlayerPrefs.HasKey("language"))
        {
            if (PlayerPrefs.GetInt("language") == 0)
            {
                for (int i = 0; i < end.Length; i++)
                {
                    end[i].SetActive(true);
                    rus[i].SetActive(false);
                    tx.text = "Won by: Player1";
                    }
            }
            else
            {
                for (int i = 0; i < end.Length; i++)
                {
                    end[i].SetActive(false);
                    rus[i].SetActive(true);
                    tx.text = "Победил: Player1";

                }
            }
        }
    }
}
    public void Game_over_blue()
    {
        if (count_blue == 3)
        {
            aud2.Play();
            ball_r.SetActive(false);
            ball_b.SetActive(false);
            pn.SetActive(true);

            Time.timeScale = 0f;
            count_red = 0;
            count_blue = 0;
            PlayerPrefs.SetInt("red", count_red);
            PlayerPrefs.SetInt("blue", count_blue);
            PlayerPrefs.Save();
            if (PlayerPrefs.HasKey("language"))
            {
                if (PlayerPrefs.GetInt("language") == 0)
                {
                    for (int i = 0; i < end.Length; i++)
                    {
                        end[i].SetActive(true);
                        rus[i].SetActive(false);
                        tx.text = "Won by: Player2";
                    }
                }
                else
                {
                    for (int i = 0; i < end.Length; i++)
                    {
                        end[i].SetActive(false);
                        rus[i].SetActive(true);
                        tx.text = "Победил: Player2";

                    }
                }
            }
        }
    }

    public void Game_over_draw()
    {
        if (count_red1 ==4 && count_blue1==4)
        {
            aud2.Play();
            count_red1 = 0;
            count_blue1 = 0;
            ball_r.SetActive(false);
            ball_b.SetActive(false);
            pn.SetActive(true);

            Time.timeScale = 0f;
            count_red = 0;
            count_blue = 0;
            PlayerPrefs.SetInt("red", count_red);
            PlayerPrefs.SetInt("blue", count_blue);
            PlayerPrefs.Save();
            if (PlayerPrefs.HasKey("language"))
            {
                if (PlayerPrefs.GetInt("language") == 0)
                {
                    for (int i = 0; i < end.Length; i++)
                    {
                        end[i].SetActive(true);
                        rus[i].SetActive(false);
                        tx.text = "Draw!";
                    }
                }
                else
                {
                    for (int i = 0; i < end.Length; i++)
                    {
                        end[i].SetActive(false);
                        rus[i].SetActive(true);
                        tx.text = "Ничья!";

                    }
                }
            }
        }
    }
    public void Plus_red()
    {
        aud.Play();
        count_red1++;
        ver_red = new Vector2(ob_red.transform.position.x, ob_red.transform.position.y + 1.3f);
    }
    public void Plus_blue()
    {
        aud.Play();
        count_blue1++;
        ver_blue = new Vector2(ob_blue.transform.position.x, ob_blue.transform.position.y + 1.3f);
    }
}
