using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IconBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	private bool _MouseIn;
	private Color _FullColor;
	void Start ()
	{
		this._MouseIn = false;
		this._FullColor = gameObject.GetComponent<RawImage>().color;
		gameObject.GetComponent<RawImage>().color = new Color32(100,100,100,100);
	}
	void Update ()
	{
		int index = int.Parse(gameObject.tag);
		Grid.CursorLocation = new Vector2(-1,-1);
		if (this._MouseIn && Input.GetKeyDown(KeyCode.Mouse0))
		{
			BuildingBehaviour.Single.ChangeSelectedBuilding(index);
		}
	}
	public void OnPointerEnter(PointerEventData eventData)
    {
		this._MouseIn = true;
		gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
		int index = int.Parse(gameObject.tag);
		BuildingBehaviour.PreviewIndex = index;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
		this._MouseIn = false;
		gameObject.GetComponent<RawImage>().color = new Color32(100,100,100,100);
		BuildingBehaviour.PreviewIndex = -1;
    }
}
