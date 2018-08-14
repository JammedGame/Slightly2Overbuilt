using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneToPlay : MonoBehaviour {

    void playScene()
    {
        SceneManager.LoadScene(PlayScene);
    }
}
