using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview 
{
	private int _SelectedIndex;
	private GameObject _Visual;
	public int SelectedIndex
	{
		get { return this._SelectedIndex; }
		set { this._SelectedIndex = value; }
	}
	public GameObject Visual
	{
		get { return this._Visual; }
		set { this._Visual = value; }
	}
	public Preview()
	{
		this._SelectedIndex = -1;
		this.CreatePlatform();
	}
	public void CreatePlatform()
	{
		GameObject Ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Ground.name = "PreviewPlatform";
		Ground.transform.localScale = new Vector3(2.2f * Element.Size, 0.25f * Element.Size, 2.2f * Element.Size);
		Ground.transform.position = new Vector3(-6 * Element.Size, Element.Size, -2 * Element.Size);
		Ground.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
	}
	public void SetForPreview(Element E)
	{
		
	}
}
