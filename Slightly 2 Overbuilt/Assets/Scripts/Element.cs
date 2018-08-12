using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
	public static float Size = 1.8f;
	public static Element Current;
	private bool _ToDestroy;
	private bool _Construct;
	private bool _ConstructAvailable;
	private int _ResType;
	private Layout _Layout;
	private Vector2 _Location;
	private Color _Paint;
	private List<Fragment> _Fragments;
	public bool ToDestroy
	{
		get { return this._ToDestroy; }
	}
	public bool Construct
	{
		get { return this._Construct; }
		set { this._Construct = value; }
	}
	public bool ConstructAvailable
	{
		get { return this._ConstructAvailable; }
		set { this._ConstructAvailable = value; }
	}
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
	public Vector2 Location
	{
		get { return this._Location; }
		set { this._Location = value; }
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
		this._ToDestroy = false;
		this._Construct = false;
		this._ConstructAvailable = false;
		this._ResType = 0;
		this._Layout = new Layout(2,2);
		this._Paint = new Color(1,1,1,1);
		this._Location = new Vector2();
		this._Fragments = new List<Fragment>();
		this._Fragments.Add(new Fragment());
	}
	public Element(int ResType, Layout Layout, List<Fragment> Fragments)
	{
		this._ToDestroy = false;
		this._Construct = false;
		this._ConstructAvailable = false;
		this._ResType = ResType;
		this._Layout = Layout;
		this._Paint = new Color(1,1,1,1);
		this._Location = new Vector2();
		this._Fragments = Fragments;
	}
	public Element(Element Old)
	{
		this._ToDestroy = false;
		this._Construct = false;
		this._ConstructAvailable = false;
		this._ResType = Old._ResType;
		this._Layout = Old._Layout.Copy();
		this._Paint = new Color(Old._Paint.r,Old._Paint.g,Old._Paint.b,Old._Paint.a);
		this._Location = new Vector2(Old._Location.x, Old._Location.y);
		this._Fragments = new List<Fragment>();
		for(int i = 0; i < Old._Fragments.Count; i++) this._Fragments.Add(Old._Fragments[i].Copy());
	}
	public Element Copy()
	{
		return new Element(this);
	}
	public void Destroy()
	{
		this._ToDestroy = true;
	}
	public void Promote()
	{
		Element.Current = this;
	}
	public void Rotate(int Direction)
	{
		this._Layout.Rotate(Direction);
	}
}
