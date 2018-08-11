using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementBehaviour : MonoBehaviour
{
	private GridElement _Element;
	void Start ()
	{
		this._Element = Grid.Single.Elements[int.Parse(gameObject.tag)];
	}
	void Update ()
	{
		//gameObject.SetActive(Grid.Visible);
	}
	void OnMouseOver()
    {
		gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        Grid.CursorLocation = this._Element.Location;
    }
    void OnMouseExit()
    {
		gameObject.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
        if(Grid.CursorLocation == this._Element.Location) Grid.CursorLocation = new Vector2(-1,-1);
    }
}
