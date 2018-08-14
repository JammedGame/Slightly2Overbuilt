using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element
{
	public static float Size = 1.8f;
	public static Element Current;
	public static Element CurrentPreview;
	private bool _ToDestroy;
	private bool _Preview;
	private bool _Construct;
	private bool _ConstructAvailable;
	private bool _GlobalRotation;
	private int _GlobalRotationValue;
	private int _ResType;
	private int _Floor;
	private float _Scale;
	private Layout _Layout;
	private Layout _ExtraLayout;
	private Vector2 _Location;
	private Color _Paint;
	private Satelite _Extra;
	private List<Fragment> _Fragments;
	public bool ToDestroy
	{
		get { return this._ToDestroy; }
	}
	public bool Preview
	{
		get { return this._Preview; }
		set { this._Preview = value; }
	}
	public bool Construct
	{
		get { return this._Construct; }
		set { this._Construct = value; }
	}
	public bool GlobalRotation
	{
		get { return this._GlobalRotation; }
		set { this._GlobalRotation = value; }
	}
	public bool ConstructAvailable
	{
		get { return this._ConstructAvailable; }
		set { this._ConstructAvailable = value; }
	}
	public int GlobalRotationValue
	{
		get { return this._GlobalRotationValue; }
		set { this._GlobalRotationValue = value; }
	}
	public int ResType
	{
		get { return this._ResType; }
		set { this._ResType = value; }
	}
	public int Floor
	{
		get { return this._Floor; }
		set { this._Floor = value; }
	}
	public float Scale
	{
		get { return this._Scale; }
		set { this._Scale = value; }
	}
	public Layout Layout
	{
		get { return this._Layout; }
		set { this._Layout = value; }
	}
	public Layout ExtraLayout
	{
		get { return this._ExtraLayout; }
		set { this._ExtraLayout = value; }
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
	public Satelite Extra
	{
		get { return this._Extra; }
		set { this._Extra = value; }
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
		this._Preview = false;
		this._GlobalRotation = false;
		this._ConstructAvailable = false;
		this._GlobalRotationValue = 0;
		this._ResType = 0;
		this._Floor = 0;
		this._Scale = 1;
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
		this._Preview = false;
		this._GlobalRotation = false;
		this._ConstructAvailable = false;
		this._GlobalRotationValue = 0;
		this._ResType = ResType;
		this._Floor = 0;
		this._Scale = 1;
		this._Layout = Layout;
		this._Paint = new Color(1,1,1,1);
		this._Location = new Vector2();
		this._Fragments = Fragments;
	}
	public Element(Element Old)
	{
		this._ToDestroy = false;
		this._Construct = false;
		this._Preview = false;
		this._GlobalRotation = false;
		this._ConstructAvailable = false;
		this._GlobalRotationValue = 0;
		this._ResType = Old._ResType;
		this._Floor = Old._Floor;
		this._Scale = Old._Scale;
		this._Layout = Old._Layout.Copy();
		if(Old._ExtraLayout != null) this._ExtraLayout = Old._ExtraLayout.Copy();
		this._Paint = new Color(Old._Paint.r,Old._Paint.g,Old._Paint.b,Old._Paint.a);
		this._Location = new Vector2(Old._Location.x, Old._Location.y);
		this._Fragments = new List<Fragment>();
		if(Old._Extra != null) this._Extra = Old._Extra.Copy();
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
		if(this._ExtraLayout != null) this._ExtraLayout.Rotate(Direction);
	}
}
