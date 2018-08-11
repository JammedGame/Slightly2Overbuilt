using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor
{
	private int _Index;
	private Layout _Layout;
	private List<Element> _Elements;
	public int Index
	{
		get { return this._Index; }
		set { this._Index = value; }
	}
	public Layout Layout
	{
		get { return this._Layout; }
		set { this._Layout = value; }
	}
	public List<Element> Elements
	{
		get { return this._Elements; }
		set { this._Elements = value; }
	}
	public Floor(int Index)
	{
		this._Index = Index;
		this._Layout = new Layout(5,5);
		this._Elements = new List<Element>();
	}
}
