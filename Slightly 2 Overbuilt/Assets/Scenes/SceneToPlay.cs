using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;



public class SceneToPlay : MonoBehaviour {


    public void playScene()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void quitGame() {
        Application.Quit();
    }

    public void soundONOFF() {

        Debug.Log("radi dugme");
        if (AudioListener.volume > 0f)
            AudioListener.volume = 0f;
        else
            AudioListener.volume = 1f;
    }
}
