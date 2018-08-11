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
		
	}
	private void CreateFragmentObjects() 
	{
		for(int i = 0; i < this._Data.Fragments.Count; i++)
		{
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.localScale = new Vector3(Element.Size, Element.Size, Element.Size);
			cube.transform.position = new Vector3(this._Data.Fragments[i].Offset.x, 0.5f, -this._Data.Fragments[i].Offset.z);
			cube.GetComponent<Renderer>().material.color = this._Data.Paint;
		}
	}
}
