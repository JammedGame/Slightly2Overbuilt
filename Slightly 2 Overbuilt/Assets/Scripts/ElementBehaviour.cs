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
		this._Data = Element.Current;
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
		if(New)
		{
			O.transform.localScale = new Vector3(Element.Size * Factor, Element.Size * Factor, Element.Size * Factor);
			O.transform.rotation = Quaternion.Euler(270,90 * F.Orientation,0);
		}
		if (E.Location.x < 0) O.transform.position = new Vector3(0, - 2.0f * Element.Size, 0);
		else
		{
			float Vertical = 0.5f * Element.Size + E.Floor * Element.Size;
			if(Extra) Vertical += E.Extra.Offset.y + E.Extra.Vertical;
			Vector2 Location = new Vector2(E.Location.x + E.Layout.LocationDiff.x, E.Location.y + E.Layout.LocationDiff.y);
			if(E.Layout.Rotation == 0) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) + F.Offset.x, Vertical, - ((Location.y - 2) * Element.Size) - F.Offset.z);
			else if(E.Layout.Rotation == 1) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) + F.Offset.z, Vertical, - ((Location.y - 2) * Element.Size) + F.Offset.x);
			else if(E.Layout.Rotation == 2) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) - F.Offset.x, Vertical, - ((Location.y - 2) * Element.Size) + F.Offset.z);
			else if(E.Layout.Rotation == 3) O.transform.position = new Vector3(((Location.x - 2) * Element.Size) - F.Offset.z, Vertical, - ((Location.y - 2) * Element.Size) - F.Offset.x);
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
