using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FloorDownBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	private bool _MouseIn;
	void Start ()
	{	
		this._MouseIn = false;
	}
	void Update ()
	{
		if (this._MouseIn && Input.GetKeyDown(KeyCode.Mouse0))
		{
			BuildingBehaviour.Single.FloorDown();
		}
	}
	public void OnPointerEnter(PointerEventData eventData)
    {
		this._MouseIn = true;
		int index = int.Parse(gameObject.tag);
		BuildingBehaviour.PreviewIndex = index;
    }
	public void OnPointerExit(PointerEventData pointerEventData)
    {
		this._MouseIn = false;
    }
}
