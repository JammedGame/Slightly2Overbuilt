using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN2 : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Panel2;


    public void showHidePanels()
    {
        Panel.gameObject.SetActive(true);
        Panel2.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
