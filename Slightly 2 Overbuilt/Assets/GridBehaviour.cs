using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
	private Grid _Grid;
	void Start ()
	{
		this._Grid = Grid.Single;
		this.CreateGridElementVisuals();
	}
	void Update ()
	{
		
	}
	private void CreateGridElementVisuals()
	{
		for(int i = 0; i < this._Grid.Elements.Count; i++)
		{
			GameObject NewObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
			NewObject.tag = i + "";
			NewObject.transform.localScale = new Vector3(Element.Size * 0.8f, 0.05f, Element.Size * 0.8f);
			NewObject.transform.position = new Vector3((this._Grid.Elements[i].Location.x - 2) * Element.Size, - 0.03f, -(this._Grid.Elements[i].Location.y - 2) * Element.Size);
			NewObject.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
			NewObject.AddComponent<GridElementBehaviour>();
		}
		
	}
}
