using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
   public void Click_language(int k)
    {
        switch (k)
        {
            case 0:
                {
                    PlayerPrefs.SetInt("language", 0);
                    PlayerPrefs.Save();
                    Application.LoadLevel(1);
                }
                break;
            case 1:
                {
                    PlayerPrefs.SetInt("language", 1);
                    PlayerPrefs.Save();
                    Application.LoadLevel(1);
                }
                break;
            default:
                break;
        }
    }
}
