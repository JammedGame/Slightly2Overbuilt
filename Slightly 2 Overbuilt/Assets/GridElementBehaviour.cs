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
		if(Grid.Visible && gameObject.transform.position.y < 0)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.025f, gameObject.transform.position.z);
		}
		else if(!Grid.Visible && gameObject.transform.position.y > 0)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, - 0.03f, gameObject.transform.position.z);
		}
	}
	void OnMouseOver()
    {
		if(this._Element == null) return;
		gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        Grid.CursorLocation = this._Element.Location;
    }
    void OnMouseExit()
    {
		if(this._Element == null) return;
		gameObject.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
        if(Grid.CursorLocation == this._Element.Location) Grid.CursorLocation = new Vector2(-1,-1);
    }
}
