using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IconBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private Color _FullColor;
	// Use this for initialization
	void Start () {
		this._FullColor = gameObject.GetComponent<RawImage>().color;
		gameObject.GetComponent<RawImage>().color = new Color32(100,100,100,100);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerEnter(PointerEventData eventData)
    {
		
		gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
		int index = int.Parse(gameObject.tag);
		BuildingBehaviour.PreviewIndex = index;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
		gameObject.GetComponent<RawImage>().color = new Color32(100,100,100,100);
		BuildingBehaviour.PreviewIndex = -1;
    }
}
