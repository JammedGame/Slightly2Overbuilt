﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
	public static float Size = 1.5f;
	public static Element Current;
	private int _ResType;
	private Layout _Layout;
	private Color _Paint;
	private List<Fragment> _Fragments;
	public int ResType
	{
		get { return this._ResType; }
		set { this._ResType = value; }
	}
	public Layout Layout
	{
		get { return this._Layout; }
		set { this._Layout = value; }
	}
	public Color Paint
	{
		get { return this._Paint; }
		set { this._Paint = value; }
	}
	public List<Fragment> Fragments
	{
		get { return this._Fragments; }
		set { this._Fragments = value; }
	}
	public Element()
	{
		this._ResType = 0;
		this._Layout = new Layout(2,2);
		this._Paint = new Color(1,1,1,1);
		this._Fragments = new List<Fragment>();
		this._Fragments.Add(new Fragment());
	}
	public Element(int ResType, Layout Layout, List<Fragment> Fragments)
	{
		this._ResType = ResType;
		this._Layout = Layout;
		this._Paint = new Color(1,1,1,1);
		this._Fragments = Fragments;
	}
	public void Promote()
	{
		Element.Current = this;
	}
}
