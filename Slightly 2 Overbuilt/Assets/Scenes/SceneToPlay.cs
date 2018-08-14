using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;



public class SceneToPlay : MonoBehaviour {

    public static bool muzikaVolume;
    public Texture zvukON;
    public Texture zvukOFF;

    public void playScene()
    {
        if (AudioListener.volume > 0f)
            muzikaVolume = true;
        else
            muzikaVolume = false;

        SceneManager.LoadScene("PlayScene");

        if (muzikaVolume)
            AudioListener.volume = 1f;
        else
            AudioListener.volume = 0f;
    }

    public void quitGame() {
        Application.Quit();
    }

    public void soundONOFF() {


        if (AudioListener.volume > 0f)
        {
            AudioListener.volume = 0f;
            //GetComponent<RawImage>().texture = zvukOFF;
        }
        else
        {
            AudioListener.volume = 1f;
           // GetComponent<RawImage>().texture = zvukON;
        }
    }
}
