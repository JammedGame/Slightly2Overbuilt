using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store
{
	private List<Element> _Elements;
	public List<Element> Elements
	{
		get { return this._Elements; }
		set { this._Elements = value; }
	}
	public Store()
	{
		this.GenerateStore();
	}
	private void GenerateStore()
	{
		this._Elements = new List<Element>();
		List<Fragment> GreenFragments = new List<Fragment>();
		GreenFragments.Add(new Fragment("", new Vector3(0, 0, 0)));
		GreenFragments.Add(new Fragment("", new Vector3(1, 0, 0)));
		GreenFragments.Add(new Fragment("", new Vector3(0, 0, 1)));
		Element Green = new Element(0, new int[2,2] {{1,1},{1,0}}, GreenFragments);
		Green.Paint = new Color(0,1,0,1);
		this._Elements.Add(Green);
	}
}
