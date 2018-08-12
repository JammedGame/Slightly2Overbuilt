using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment
{
	private string _ArtName;
	private Vector3 _Offset;
	private GameObject _Object;
	public string ArtName
	{
		get { return this._ArtName; }
		set { this._ArtName = value; }
	}
	public Vector3 Offset
	{
		get { return this._Offset; }
		set { this._Offset = value; }
	}
	public GameObject Object
	{
		get { return this._Object; }
		set { this._Object = value; }
	}
	public Fragment()
	{
		this._ArtName = "";
		this._Offset = new Vector3();
	}
	public Fragment(string ArtName, Vector3 Offset)
	{
		this._ArtName = ArtName;
		this._Offset = Offset;
	}
	public Fragment(Fragment Old)
	{
		this._ArtName = Old._ArtName;
		this._Offset = new Vector3(Old._Offset.x, Old._Offset.y, Old._Offset.z);
	}
	public Fragment Copy()
	{
		return new Fragment(this);
	}
}
