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
		GreenFragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
		GreenFragments.Add(new Fragment("", new Vector3(Element.Size, 	0,				0)));
		GreenFragments.Add(new Fragment("", new Vector3(0, 				0, 				Element.Size)));
		Element Green = new Element(0, new Layout(2,2,new int[2,2] {{1,1},{1,0}}), GreenFragments);
		Green.Paint = new Color(0,0.6f,0,1);
		this._Elements.Add(Green);

		List<Fragment> RedFragments = new List<Fragment>();
		RedFragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
		RedFragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
		RedFragments.Add(new Fragment("", new Vector3(2 * Element.Size, 	0, 				0)));
		Element Red = new Element(0, new Layout(3,1,new int[1,3] {{1,1,1}}), RedFragments);
		Red.Paint = new Color(0.6f,0,0,1);
		this._Elements.Add(Red);

		List<Fragment> BlueFragments = new List<Fragment>();
		BlueFragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
		BlueFragments.Add(new Fragment("", new Vector3(0, 				0, 				Element.Size)));
		BlueFragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
		BlueFragments.Add(new Fragment("", new Vector3(2 * Element.Size, 	0, 				0)));
		Element Blue = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {1,0,0}}), BlueFragments);
		Blue.Paint = new Color(0,0,0.6f,1);
		this._Elements.Add(Blue);
	}
}
