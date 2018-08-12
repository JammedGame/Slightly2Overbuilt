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

		this.AddNewElement(2, new Color32(0x78, 0xB3, 0xB9, 0xFF)); // Water
		this.AddNewElement(2, new Color32(0xF9, 0x95, 0x03, 0xFF)); // Food
		this.AddNewElement(2, new Color32(0x88, 0x72, 0x5D, 0xFF)); // Fuel
		this.AddNewElement(3, new Color32(0xBD, 0x3D, 0x3C, 0xFF)); // Textile
		this.AddNewElement(3, new Color32(0xE4, 0xBE, 0x5D, 0xFF)); // Wood
		this.AddNewElement(3, new Color32(0xAE, 0xAC, 0x97, 0xFF)); // Metal
		this.AddNewElement(3, new Color32(0x51, 0xE6, 0xAE, 0xFF)); // Glass
		this.AddNewElement(4, new Color32(0x65, 0x64, 0x76, 0xFF)); // Rubber
		this.AddNewElement(4, new Color32(0xFF, 0xF7, 0xFA, 0xFF)); // Plastic
		this.AddNewElement(4, new Color32(0xFF, 0xFF, 0x85, 0xFF)); // Electicity
	}
	private void AddNewElement(int Size, Color Paint)
	{
		Element NewElement = this.GenerateElementLayout(Size);
		NewElement.Paint = Paint;
		this._Elements.Add(NewElement);
	}
	private string RandomArt()
	{
		int Index = Random.Range(0,6);
		return "cube0"+(Index+1);
	}
	private Element GenerateElementLayout(int Size)
	{
		List<Fragment> Fragments = new List<Fragment>();
		if(Size == 2)
		{
			Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
			Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
			Element NewElement = new Element(0, new Layout(2,1,new int[1,2] {{1,1}}), Fragments);
			return NewElement;
		}
		else if(Size == 3)
		{
			int Chosen = Random.Range(0,2);
			if(Chosen == 0)
			{
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 	0,				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(2,2,new int[2,2] {{1,1},{1,0}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 1)
			{
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,1,new int[1,3] {{1,1,1}}), Fragments);
				return NewElement;
			}
		}
		else if(Size == 4)
		{
			int Chosen = Random.Range(0,5);
			if(Chosen == 0)
			{
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(3 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(4,1,new int[1,4] {{1,1,1,1}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 1)
			{
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0,				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(2,2,new int[2,2] {{1,1},{1,1}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 2)
			{
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {1,0,0}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 3)
			{
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 					0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,0}, {0,1,1}}), Fragments);
				return NewElement;
			}
			else if(Chosen == 4)
			{
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {0,1,0}}), Fragments);
				return NewElement;
			}
		}
		return null;
	}
}
