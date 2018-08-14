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
		this._FullColor = new Color(this._FullColor.r, this._FullColor.g, this._FullColor.b, this._FullColor.a);
		gameObject.GetComponent<RawImage>().color = new Color32(100,100,100,100);
	}
	void Update ()
	{
		int index = int.Parse(gameObject.tag);
		if (this._MouseIn && Input.GetKeyDown(KeyCode.Mouse0) && ResourcePool.Single.AreReqsMet(index))
		{
			Grid.CursorLocation = new Vector2(-1,-1);
			BuildingBehaviour.Single.ChangeSelectedBuilding(index);
		}
		if(this._MouseIn)
		{
			gameObject.GetComponent<RawImage>().color = new Color32(255, 255, 255, 255);
		}
		else
		{
			if(ResourcePool.Single.IsDone(index))
			{
				gameObject.GetComponent<RawImage>().color = this._FullColor;
			}
			else gameObject.GetComponent<RawImage>().color = new Color32(100,100,100,100);
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
		BuildingBehaviour.PreviewIndex = -1;
    }
}
