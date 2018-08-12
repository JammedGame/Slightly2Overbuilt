using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hidePanel2 : MonoBehaviour {

    void Start() {

        hidePanels();
    }

    public GameObject Panel;
   

    public void hidePanels() { 
    Panel.gameObject.SetActive (false);
  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
