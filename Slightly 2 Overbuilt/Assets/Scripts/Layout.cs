using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layout
{
	private int _Rotation;
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
	public Vector2 LocationDiff
	{
		get { return this.GetLocationDiff(); }
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
	public Layout Invert()
	{
		Layout NewLayout = this.Copy();
		for(int i = 0; i < this._Size.y; i++)
		{
			for(int j = 0; j < this._Size.x; j++)
			{
				NewLayout._Fields[i,j] = (NewLayout._Fields[i,j] > 0) ? 0 : 1;
			}
		}
		return NewLayout;
	}
	public bool CanApply(Vector2 Location, Layout L2)
	{
		Layout L1 = this.Invert();
		Location = new Vector2(Location.x + L2.LocationDiff.x, Location.y + L2.LocationDiff.y);
		return this.Check(Location, L1, L2);
	}
	public bool CanSupport(Vector2 Location, Layout L2)
	{
		Location = new Vector2(Location.x + L2.LocationDiff.x, Location.y + L2.LocationDiff.y);
		return this.Check(Location, this, L2);
	}
	public void Apply(Vector2 Location, Layout L2)
    {
        Location = new Vector2(Location.x + L2.LocationDiff.x, Location.y + L2.LocationDiff.y);
		for(int i = 0; i < L2._Size.y; i++)
		{
			for(int j = 0; j < L2._Size.x; j++)
			{
				if(L2._Fields[i,j] == 1)
				{
					this._Fields[(int)Location.y + i, (int)Location.x + j] = 1;
				}
			}
		}
    }
	private bool Check(Vector2 Location, Layout L1, Layout L2)
	{
		if(Location.x < 0 || Location.y < 0) return false;
        if(Location.x + L2.Size.x > this._Size.x) return false;
        if(Location.y + L2.Size.y > this._Size.y) return false;
        for(int i = 0; i < L2.Size.x; i++)
        {
            for(int j = 0; j < L2.Size.y; j++)
            {
                if(L2._Fields[j, i] == 1)
                {
                    if(L1._Fields[(j + (int)Location.y), (i + (int)Location.x)] != 1) return false;
                }
            }
        }
        return true;
	}
	public void Rotate(int Direction)
	{
		int[,] NewFields = new int[(int)this._Size.x, (int)this._Size.y];
		if(Direction == -1)
		{
			for(int i = 0; i < this._Size.y; i++)
			{
				for(int j = 0; j < this._Size.x; j++)
				{
					NewFields[j, ((int)this._Size.x) - i - 1] = this._Fields[i,j];
				}
			}
		}
		else if(Direction == 1)
		{
			for(int i = 0; i < this._Size.y; i++)
			{
				for(int j = 0; j < this._Size.x; j++)
				{
					NewFields[((int)this._Size.y) - j - 1, i] = this._Fields[i,j];
				}
			}
		}
		this._Size = new Vector2(this._Size.y, this._Size.x);
		this._Fields = NewFields;
		this._Rotation += Direction;
		if(this._Rotation > 3) this._Rotation = 0;
		if(this._Rotation < 0) this._Rotation = 3;
		Debug.Log(this._Rotation);
		this.Print();
	}
	private Vector2 GetLocationDiff()
	{
		if(this._Rotation == 0) return new Vector2(0,					0);
		if(this._Rotation == 1) return new Vector2(0,					this._Size.y - 1);
		if(this._Rotation == 2) return new Vector2(this._Size.x - 1,	this._Size.y - 1);
		if(this._Rotation == 3) return new Vector2(this._Size.x - 1,	0);
		return new Vector2();
	}
	private void Print()
	{
		for(int i = 0; i < this._Size.y; i++)
		{
			string Line = "";
			for(int j = 0; j < this._Size.x; j++)
			{
				if(j>0) Line+=",";
				Line+=this._Fields[i,j];
			}
			Debug.Log(Line);
		}
	}
}
