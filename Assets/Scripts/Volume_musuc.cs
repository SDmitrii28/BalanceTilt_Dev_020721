using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume_musuc : MonoBehaviour
{
    private int music;
    public GameObject btn_on;
    public GameObject btn_off;
    public AudioSource aud;
    public AudioMixerGroup mixer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("music"))
        {
            music = PlayerPrefs.GetInt("music");
        }
        else
            music = 0;
        //////////////////
        if (music == 0)
        {
            mixer.audioMixer.SetFloat("MyExposedParam 2", 0);
            PlayerPrefs.SetInt("music", music);
            btn_on.SetActive(true);
            btn_off.SetActive(false);
        }
        if (music == 1)
        {
            mixer.audioMixer.SetFloat("MyExposedParam 2", -80);
            PlayerPrefs.SetInt("music", music);
            btn_on.SetActive(false);
            btn_off.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click_on()
    {
        mixer.audioMixer.SetFloat("MyExposedParam 2", -80);
        aud.Play();
        music = 1;
        PlayerPrefs.SetInt("music", music);
        PlayerPrefs.Save();
        btn_on.SetActive(false);
        btn_off.SetActive(true);
    }
    public void Click_off()
    {
        mixer.audioMixer.SetFloat("MyExposedParam 2", 0);
        aud.Play();
        music = 0;
        PlayerPrefs.SetInt("music", music);
        btn_on.SetActive(true);
        btn_off.SetActive(false);
    }
}
