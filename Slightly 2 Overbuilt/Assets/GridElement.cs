using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement
{
	private Vector2 _Location;
	public Vector2 Location
	{
		get { return this._Location; }
		set { this._Location = value; }
	}
	public GridElement(Vector2 Location)
	{
		this._Location = Location;
	}
}
