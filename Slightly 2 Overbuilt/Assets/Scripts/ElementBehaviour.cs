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
			if (this._Data.Location.x < 0) FragmentObject.transform.position = new Vector3(0, - 1.2f * Element.Size, 0);
			else
			{
				float Vertical = 0.5f * Element.Size + this._Data.Floor * Element.Size;
				Vector2 Location = new Vector2(this._Data.Location.x + this._Data.Layout.LocationDiff.x, this._Data.Location.y + this._Data.Layout.LocationDiff.y);
				if(this._Data.Layout.Rotation == 0) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) + this._Data.Fragments[i].Offset.x, Vertical, - ((Location.y - 2) * Element.Size) - this._Data.Fragments[i].Offset.z);
				else if(this._Data.Layout.Rotation == 1) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) + this._Data.Fragments[i].Offset.z, Vertical, - ((Location.y - 2) * Element.Size) + this._Data.Fragments[i].Offset.x);
				else if(this._Data.Layout.Rotation == 2) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) - this._Data.Fragments[i].Offset.x, Vertical, - ((Location.y - 2) * Element.Size) + this._Data.Fragments[i].Offset.z);
				else if(this._Data.Layout.Rotation == 3) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) - this._Data.Fragments[i].Offset.z, Vertical, - ((Location.y - 2) * Element.Size) - this._Data.Fragments[i].Offset.x);
			}
			if(this._Data.Construct)
			{
				if(this._Data.ConstructAvailable) FragmentObject.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
				else FragmentObject.GetComponent<Renderer>().material.color = new Color(1,0,0,1);
			}
		}
	}
	private void CreateFragmentObjects() 
	{
		for(int i = 0; i < this._Data.Fragments.Count; i++)
		{
			GameObject FragmentObject = GameObject.Instantiate((GameObject)Resources.Load(this._Data.Fragments[i].ArtName));
			int Factor = 50;
			FragmentObject.transform.localScale = new Vector3(Element.Size * Factor, Element.Size * Factor, Element.Size * Factor);
			FragmentObject.transform.rotation = Quaternion.Euler(270,90 * this._Data.Fragments[i].Orientation,0);
			if (this._Data.Location.x < 0) FragmentObject.transform.position = new Vector3(0, - 1.2f * Element.Size, 0);
			else
			{
				float Vertical = 0.5f * Element.Size + this._Data.Floor * Element.Size;
				Vector2 Location = new Vector2(this._Data.Location.x + this._Data.Layout.LocationDiff.x, this._Data.Location.y + this._Data.Layout.LocationDiff.y);
				if(this._Data.Layout.Rotation == 0) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) + this._Data.Fragments[i].Offset.x, Vertical, - ((Location.y - 2) * Element.Size) - this._Data.Fragments[i].Offset.z);
				else if(this._Data.Layout.Rotation == 1) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) + this._Data.Fragments[i].Offset.z, Vertical, - ((Location.y - 2) * Element.Size) + this._Data.Fragments[i].Offset.x);
				else if(this._Data.Layout.Rotation == 2) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) - this._Data.Fragments[i].Offset.x, Vertical, - ((Location.y - 2) * Element.Size) + this._Data.Fragments[i].Offset.z);
				else if(this._Data.Layout.Rotation == 3) FragmentObject.transform.position = new Vector3(((Location.x - 2) * Element.Size) - this._Data.Fragments[i].Offset.z, Vertical, - ((Location.y - 2) * Element.Size) - this._Data.Fragments[i].Offset.x);
			}
			if(!this._Data.Construct) FragmentObject.GetComponent<Renderer>().material.color = this._Data.Paint;
			else FragmentObject.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
			Destroy(FragmentObject.GetComponent<Collider>());
			this._Data.Fragments[i].Object = FragmentObject;
		}
	}
}
