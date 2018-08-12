using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout
{
	private Vector2 _Size;
	private int[,] _Fields;
	public Vector2 Size
	{
		get { return this._Size; }
		set { this._Size = value; }
	}
	public int[,] Fields
	{
		get { return this._Fields; }
		set { this._Fields = value; }
	}
	public Layout(int x, int y)
	{
		this._Size = new Vector2(x,y);
		this._Fields = new int[y,x];
		for(int i = 0; i < y; i++)
		{
			for(int j = 0; j < x; j++)
			{
				this._Fields[i,j] = 0;
			}
		}
	}
	public Layout(int x, int y, int[,] Values) : this(x,y)
	{
		for(int i = 0; i < y; i++)
		{
			for(int j = 0; j < x; j++)
			{
				this._Fields[i,j] = Values[i,j];
			}
		}
	}
	public Layout(Layout Old) : this((int)Old._Size.x, (int)Old._Size.y, Old._Fields)
	{

	}
	public Layout Copy()
	{
		return new Layout(this);
	}
}
