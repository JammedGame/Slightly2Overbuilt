using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
	public static bool Visible;
	public static int Vertical;
	public static Grid Single;
	public static Vector2 CursorLocation;
	private List<GridElement> _Elements;
	public List<GridElement> Elements
	{
		get { return this._Elements; }
	}
	public Grid()
	{
		Grid.Visible = false;
		Grid.Vertical = 0;
		this._Elements = new List<GridElement>();
		this.CreateGridElements();
		Grid.Single = this;
	}
	private void CreateGridElements()
	{
		for(int i = 0; i < 5; i++)
		{
			for(int j = 0; j < 5; j++)
			{
				this._Elements.Add(new GridElement(new Vector2(j, i)));
			}	
		}
	}
}
