using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTN22 : MonoBehaviour
{

    public GameObject Panel;
    public GameObject Panel2;


    public void showHidePanels()
    {
        Panel2.gameObject.SetActive(true);
        Panel.gameObject.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
