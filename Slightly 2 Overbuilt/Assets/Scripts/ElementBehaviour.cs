using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ElementBehaviour : MonoBehaviour
{
	private Element _Data;
	void Start ()
	{
		Store S = new Store();
		if(gameObject.tag != "PreviewElement")
		{
			this._Data = Element.Current;
		}
		else
		{
			this._Data = Element.CurrentPreview;
		}
		this.CreateFragmentObjects();
	}
	void Update ()
	{
		if(this._Data != null && this._Data.ToDestroy)
		{
			for(int i = 0; i < this._Data.Fragments.Count; i++)
			{
				Destroy(this._Data.Fragments[i].Object);
			}
			if(this._Data.Extra != null)
			{
				Destroy(this._Data.Extra.Object);
			}
			Destroy(gameObject);
		}
		else UpdateFragmentObjects();
	}
	private void UpdateFragmentObjects()
	{
		if(this._Data == null) return;
		for(int i = 0; i < this._Data.Fragments.Count; i++)
		{
			GameObject FragmentObject = this._Data.Fragments[i].Object;
			this.UpdateFragment(this._Data, this._Data.Fragments[i], FragmentObject, false, false);
		}
		if(this._Data.Extra != null)
		{
			GameObject FragmentObject = this._Data.Extra.Object;
			this.UpdateFragment(this._Data, this._Data.Extra, FragmentObject, true, false);
		}
	}
	private void CreateFragmentObjects() 
	{
		for(int i = 0; i < this._Data.Fragments.Count; i++)
		{
			GameObject FragmentObject = GameObject.Instantiate((GameObject)Resources.Load(this._Data.Fragments[i].ArtName));
			this.UpdateFragment(this._Data, this._Data.Fragments[i], FragmentObject, false, true);
		}
		if(this._Data.Extra != null)
		{
			GameObject FragmentObject = GameObject.Instantiate((GameObject)Resources.Load(this._Data.Extra.ArtName));
			this.UpdateFragment(this._Data, this._Data.Extra, FragmentObject, true, true);
		}
	}
	private void UpdateFragment(Element E, Fragment F, GameObject O, bool Extra, bool New)
	{
		float Factor = 50;
		if(Extra && E.Extra.ArtName == "satelite02") Factor = 0.4f;
		float OSize = Element.Size * E.Scale;
		if(New)
		{
			O.transform.localScale = new Vector3(OSize * Factor, OSize * Factor, OSize * Factor);
			O.transform.rotation = Quaternion.Euler(270,90 * F.Orientation,0);
		}
		if (E.Location.x < 0) O.transform.position = new Vector3(0, - 2.0f * OSize, 0);
		else
		{
			float Vertical = 0.5f * OSize + E.Floor * OSize;
			if(E.Preview) Vertical = 0.5f * OSize + E.Floor * OSize;
			if(Extra) Vertical += E.Extra.Offset.y * E.Scale + E.Extra.Vertical * E.Scale;
			Vector2 Location = new Vector2(E.Location.x + E.Layout.LocationDiff.x, E.Location.y + E.Layout.LocationDiff.y);
			if(E.Preview) Location = new Vector2(-5, 3);
			if(E.Layout.Rotation == 0 || E.Preview) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) + F.Offset.x * E.Scale, Vertical, - ((Location.y - 2) * Element.Size) - F.Offset.z * E.Scale);
			else if(E.Layout.Rotation == 1) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) + F.Offset.z * E.Scale, Vertical, - ((Location.y - 2) * Element.Size) + F.Offset.x * E.Scale);
			else if(E.Layout.Rotation == 2) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) - F.Offset.x * E.Scale, Vertical, - ((Location.y - 2) * Element.Size) + F.Offset.z * E.Scale);
			else if(E.Layout.Rotation == 3) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) - F.Offset.z * E.Scale, Vertical, - ((Location.y - 2) * Element.Size) - F.Offset.x * E.Scale);
		}
		if(E.Construct)
		{
			if(E.ConstructAvailable) O.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
			else O.GetComponent<Renderer>().material.color = new Color(1,0,0,1);
		}
		else O.GetComponent<Renderer>().material.color = E.Paint;
		if(New)
		{
			Destroy(O.GetComponent<Collider>());
			F.Object = O;
		}
	}
}
