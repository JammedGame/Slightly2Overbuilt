using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElementBehaviour : MonoBehaviour
{
	private int _Vertical;
	private GridElement _Element;
	void Start ()
	{
		this._Vertical = 0;
		this._Element = Grid.Single.Elements[int.Parse(gameObject.tag)];
	}
	void Update ()
	{
		if((Grid.Visible && gameObject.transform.position.y < 0) || (Grid.Visible && this._Vertical != Grid.Vertical))
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.025f + Grid.Vertical * Element.Size, gameObject.transform.position.z);
		}
		else if(!Grid.Visible && gameObject.transform.position.y > 0)
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, - 0.03f, gameObject.transform.position.z);
		}
		this._Vertical = Grid.Vertical;
	}
	void OnMouseOver()
    {
		if(this._Element == null) return;
		gameObject.GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        Grid.CursorLocation = this._Element.Location;
    }
    void OnMouseExit()
    {
		int i = int.Parse(gameObject.tag);
		if(this._Element == null) return;
		if(i % 2 == 0) gameObject.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 1);
		else gameObject.GetComponent<Renderer>().material.color = new Color(0.7f, 0.7f, 0.7f, 1);
        if(Grid.CursorLocation == this._Element.Location) Grid.CursorLocation = new Vector2(-1,-1);
    }
}
