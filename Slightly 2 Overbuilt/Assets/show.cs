using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class show : MonoBehaviour {

    static public GameObject resurs1;
    static public GameObject resurs2;
    static public GameObject resurs3;

    void Start() {
        resurs1 = GameObject.Find("resurs1");
        resurs2 = GameObject.Find("resurs2");
        resurs3 = GameObject.Find("resurs3");
        resurs1.SetActive(false);
        resurs2.SetActive(false);
        resurs3.SetActive(false);
    }

    public void prikazi() {
        resurs1.SetActive(true);
        
    }
}
