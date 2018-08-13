using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview 
{
	private int _SelectedIndex;
	private Element _Current;
	private GameObject _Visual;
	private GameObject _Platform;
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
		Ground.transform.localScale = new Vector3(2.0f * Element.Size, 0.125f * Element.Size, 2.0f * Element.Size);
		Ground.transform.position = new Vector3(0, -2.0f, 0);
		Ground.GetComponent<Renderer>().material.color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
		this._Platform = Ground;
	}
	public void SetForPreview(Element E, int Floor)
	{
		if(this._Current != null)
		{
			this._Current.Destroy();
		}
		if(E != null)
		{
			E = E.Copy();
			this._Current = E;
			E.Floor = (Floor+1)*2;
			E.Paint = new Color(0.3f, 0.3f, 0.3f, 1.0f);
			E.Scale = 0.5f;
			E.Preview = true;
			Element.CurrentPreview = E;
			GameObject NewObject = new GameObject("PreviewElementObject");
			NewObject.tag = "PreviewElement";
			NewObject.AddComponent<ElementBehaviour>();
			float XOffset = 0;
			if(E.Layout.Size.x == 1) XOffset = 1.5f * Element.Size;
			if(E.Layout.Size.x == 2) XOffset = 0.5f * Element.Size;
			if(E.Layout.Size.x == 3) XOffset = 0.25f * Element.Size;
			float YOffset = 0;
			if(E.Layout.Size.y == 1) YOffset = 1.5f * Element.Size;
			if(E.Layout.Size.y == 2) YOffset = 0.5f * Element.Size;
			if(E.Layout.Size.y == 3) YOffset = 0.25f * Element.Size;
			this._Platform.transform.localScale = new Vector3(E.Layout.Size.x * 0.5f * Element.Size, 0.125f * Element.Size, E.Layout.Size.y * 0.5f * Element.Size);
			this._Platform.transform.position = new Vector3(-6.25f * Element.Size - XOffset, (( 1 + Floor ) * Element.Size) - 0.0625f * Element.Size, -1.75f * Element.Size + XOffset);
		}
		else
		{
			this._Platform.transform.position = new Vector3(0, -2.0f, 0);
		}
	}
}
