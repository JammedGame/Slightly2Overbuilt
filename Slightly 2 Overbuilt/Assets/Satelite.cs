using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satelite : Fragment
{
	private float _Vertical;
	public float Vertical
	{
		get { return this._Vertical; }
		set { this._Vertical = value; }
	}
	public Satelite() : base()
	{
		this._Vertical = 0;
	}
	public Satelite(string ArtName, Vector3 Offset) : base(ArtName, Offset)
	{
		this._Vertical = 0;
	}
	public Satelite(Satelite Old) : base(Old)
	{
		this._Vertical = Old._Vertical;
	}
	public new Satelite Copy()
	{
		return new Satelite(this);
	}
}
