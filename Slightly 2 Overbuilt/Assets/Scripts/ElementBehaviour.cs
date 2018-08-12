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
		Debug.Log(this._Data.ResType);
	}
	void Update ()
	{
		if(this._Data.ToDestroy)
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
		for(int i = 0; i < this._Data.Fragments.Count; i++)
		{
			GameObject FragmentObject = this._Data.Fragments[i].Object;
			if (this._Data.Location.x < 0) FragmentObject.transform.position = new Vector3(0, - 1.2f * Element.Size, 0);
			else FragmentObject.transform.position = new Vector3(((this._Data.Location.x - 2) * Element.Size) + this._Data.Fragments[i].Offset.x, 0.5f, - ((this._Data.Location.y - 2) * Element.Size) - this._Data.Fragments[i].Offset.z);
		}
	}
	private void CreateFragmentObjects() 
	{
		for(int i = 0; i < this._Data.Fragments.Count; i++)
		{
			GameObject FragmentObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			FragmentObject.transform.localScale = new Vector3(Element.Size, Element.Size, Element.Size);
			if (this._Data.Location.x < 0) FragmentObject.transform.position = new Vector3(0, - 1.2f * Element.Size, 0);
			else FragmentObject.transform.position = new Vector3(((this._Data.Location.x - 2) * Element.Size) + this._Data.Fragments[i].Offset.x, 0.5f, - ((this._Data.Location.y - 2) * Element.Size) - this._Data.Fragments[i].Offset.z);
			if(!this._Data.Construct) FragmentObject.GetComponent<Renderer>().material.color = this._Data.Paint;
			else FragmentObject.GetComponent<Renderer>().material.color = new Color(1,1,1,1);
			Destroy(FragmentObject.GetComponent<Collider>());
			this._Data.Fragments[i].Object = FragmentObject;
		}
	}
}
