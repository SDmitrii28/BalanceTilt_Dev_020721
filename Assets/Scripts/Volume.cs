using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
    private int sound;
    public GameObject btn_on;
    public GameObject btn_off;
    public AudioSource aud;
    public AudioMixerGroup mixer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("sound"))
        {
            sound = PlayerPrefs.GetInt("sound");
        }
        else
            sound = 0;
        //////////////////
        if (sound == 0)
        {
            mixer.audioMixer.SetFloat("MyExposedParam", 0);
            PlayerPrefs.SetInt("sound", sound);
            btn_on.SetActive(true);
            btn_off.SetActive(false);
        }
        if (sound == 1)
        {
            mixer.audioMixer.SetFloat("MyExposedParam", -80);
            PlayerPrefs.SetInt("sound", sound);
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
        mixer.audioMixer.SetFloat("MyExposedParam", -80);
        aud.Play();
        sound = 1;
        PlayerPrefs.SetInt("sound", sound);
        PlayerPrefs.Save();
        btn_on.SetActive(false);
        btn_off.SetActive(true);
    }
    public void Click_off()
    {
        mixer.audioMixer.SetFloat("MyExposedParam", 0);
        aud.Play();
        sound = 0;
        PlayerPrefs.SetInt("sound", sound);
        btn_on.SetActive(true);
        btn_off.SetActive(false);
    }
}
