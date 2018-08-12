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

		Element Green = this.GenerateElementLayout(3);
		Green.Paint = new Color(0,0.6f,0,1);
		this._Elements.Add(Green);

		Element Red = this.GenerateElementLayout(3);
		Red.Paint = new Color(0.6f,0,0,1);
		this._Elements.Add(Red);

		Element Blue = this.GenerateElementLayout(4);
		Blue.Paint = new Color(0,0,0.6f,1);
		this._Elements.Add(Blue);
	}
	private Element GenerateElementLayout(int Size)
	{
		List<Fragment> Fragments = new List<Fragment>();
		if(Size == 2)
		{
			Fragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
			Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
			Element NewElement = new Element(0, new Layout(2,1,new int[1,2] {{1,1}}), Fragments);
			return NewElement;
		}
		else if(Size == 3)
		{
			int Chosen = Random.Range(0,2);
			if(Chosen == 0)
			{
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 	0,				0)));
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(2,2,new int[2,2] {{1,1},{1,0}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 1)
			{
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,1,new int[1,3] {{1,1,1}}), Fragments);
				return NewElement;
			}
		}
		else if(Size == 4)
		{
			int Chosen = Random.Range(0,5);
			if(Chosen == 0)
			{
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(2 * Element.Size, 	0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(3 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(4,1,new int[1,4] {{1,1,1,1}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 1)
			{
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 	0,				0)));
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 	0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(2,2,new int[2,2] {{1,1},{1,1}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 2)
			{
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {1,0,0}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 3)
			{
				Fragments.Add(new Fragment("", new Vector3(0, 					0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment("", new Vector3(2 * Element.Size, 	0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,0}, {0,1,1}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 4)
			{
				Fragments.Add(new Fragment("", new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment("", new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment("", new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {0,1,0}}), Fragments);
				return NewElement;
			}
		}
		return null;
	}
}
