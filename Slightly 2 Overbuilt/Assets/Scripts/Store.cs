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
		Element Wood = this.AddNewElement(3, new Color32(0xE4, 0xBE, 0x5D, 0xFF), "satelite02"); // Wood
		Wood.Extra.Vertical = Element.Size * 1.6f;
		this.AddNewElement(3, new Color32(0xAE, 0xAC, 0x97, 0xFF)); // Metal
		this.AddNewElement(3, new Color32(0x51, 0xE6, 0xAE, 0xFF)); // Glass
		this.AddNewElement(4, new Color32(0x65, 0x64, 0x76, 0xFF), "satelite01"); // Rubber
		this.AddNewElement(4, new Color32(0xFF, 0xF7, 0xFA, 0xFF)); // Plastic
		this.AddNewElement(4, new Color32(0xFF, 0xFF, 0x85, 0xFF)); // Electicity
		this.AddNewElement(5, new Color32(0x4A, 0x93, 0x44, 0xFF)); // Electronics
		this.AddNewElement(5, new Color32(0x02, 0x97, 0x5D, 0xFF)); // Pharmaceuticals
		for(int i = 0; i < 12; i++) this._Elements[i].ResType = i;
	}
	private Element AddNewElement(int Size, Color Paint, string Extra = "")
	{
		Element NewElement = this.GenerateElementLayout(Size, Extra);
		NewElement.Paint = Paint;
		this._Elements.Add(NewElement);
		return NewElement;
	}
	private string RandomArt()
	{
		int Index = Random.Range(0,9);
		return "cube0"+(Index+1);
	}
	private Element GenerateElementLayout(int Size, string Extra)
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
			int Chosen = Random.Range(0,3);
			int EI = Random.Range(0,3);
			if(Chosen == 1 || Chosen == 0)
			{
				// XX
				// X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 	0,				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(2,2,new int[2,2] {{1,1},{1,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(2,2,new int[2,2] {{0,0},{0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,0] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 2)
			{
				// XXX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,1,new int[1,3] {{1,1,1}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,1,new int[1,3] {{0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[0,2] = 1;
				}
				return NewElement;
			}
		}
		else if(Size == 4)
		{
			int Chosen = Random.Range(0,5);
			int EI = Random.Range(0,4);
			if(Chosen == 0)
			{
				// XXXX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(3 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(4,1,new int[1,4] {{1,1,1,1}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(4,1,new int[1,4] {{0,0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[0,2] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[0,3] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 1)
			{
				// XX
				// XX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0,				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(2,2,new int[2,2] {{1,1},{1,1}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(2,2,new int[2,2] {{0,0},{0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,0] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,1] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 2)
			{
				// XXX
				// X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {1,0,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,2,new int[2,3] {{0,0,0}, {0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[1,0] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[0,2] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 3)
			{
				// XX
				//  XX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,0}, {0,1,1}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,2,new int[2,3] {{0,0,0}, {0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,2] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 4)
			{
				// XXX
				//  X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {0,1,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,2,new int[2,3] {{0,0,0}, {0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[0,2] = 1;
				}
				return NewElement;
			}
		}
		else if(Size == 5)
		{
			int Chosen = Random.Range(0,10);
			int EI = Random.Range(0,4);
			if(Chosen == 0)
			{
				// XXX
				// XX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {1,1,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,2,new int[2,3] {{0,0,0}, {0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[0,2] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,0] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[1,1] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 1)
			{
				// XX
				//  XX
				//  X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size,		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				2 * Element.Size)));
				Element NewElement = new Element(0,new Layout(3,3,new int[3,3] {{1,1,0},{0,1,1},{0,1,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,3,new int[3,3] {{0,0,0},{0,0,0},{0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,2] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[2,1] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 2)
			{
				// X
				// X
				// X
				// XX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size,		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size,	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(3 * Element.Size,	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(4,2,new int[2,4] {{1,1,1,1},{1,0,0,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(4,2,new int[2,4] {{0,0,0,0},{0,0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[0,2] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[0,3] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[1,0] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 3)
			{
				//  X
				// XXX
				//  X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size,		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				2 * Element.Size)));
				Element NewElement = new Element(0,new Layout(3,3,new int[3,3] {{0,1,0},{1,1,1},{0,1,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,3,new int[3,3] {{0,0,0},{0,0,0},{0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[1,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,2] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[2,1] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 4)
			{
				// XX
				//  XXX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(3 * Element.Size, 	0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(4,2,new int[2,4] {{1,1,0,0},{0,1,1,1}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(4,2,new int[2,4] {{0,0,0,0},{0,0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,2] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[1,3] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 5)
			{
				// XXX
				// X X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				Element.Size)));
				Element NewElement = new Element(0, new Layout(3,2,new int[2,3] {{1,1,1}, {1,0,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,2,new int[2,3] {{0,0,0}, {0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[1,0] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[0,2] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[1,2] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 6)
			{
				// XXX
				//  X
				//  X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size,		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				2 * Element.Size)));
				Element NewElement = new Element(0,new Layout(3,3,new int[3,3] {{1,1,1},{0,1,0},{0,1,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,3,new int[3,3] {{0,0,0},{0,0,0},{0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[0,2] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[2,1] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 7)
			{
				// XXX
				// X
				// X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size,		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size,	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				2 * Element.Size)));
				Element NewElement = new Element(0, new Layout(3,3,new int[3,3] {{1,1,1},{1,0,0},{1,0,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,3,new int[3,3] {{0,0,0},{0,0,0},{0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[0,2] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,0] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[2,0] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 8)
			{
				//  XX
				// XX
				// X
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size,	0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size,		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				2 * Element.Size)));
				Element NewElement = new Element(0, new Layout(3,3,new int[3,3] {{0,1,1},{1,1,0},{1,0,0}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,3,new int[3,3] {{0,0,0},{0,0,0},{0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,2] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[1,0] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[2,0] = 1;
				}
				return NewElement;
			}
			else if(Chosen == 9)
			{
				// XX
				//  X
				//  XX
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(0, 				0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size,		0, 				0)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(2 * Element.Size, 	0, 				2 * Element.Size)));
				Fragments.Add(new Fragment(this.RandomArt(), new Vector3(Element.Size, 		0, 				2 * Element.Size)));
				Element NewElement = new Element(0,new Layout(3,3,new int[3,3] {{1,1,0},{0,1,0},{0,1,1}}), Fragments);
				if(Extra != "")
				{
					NewElement.Extra = new Satelite(Extra, new Vector3(Fragments[EI].Offset.x, Element.Size, Fragments[EI].Offset.z));
					NewElement.ExtraLayout = new Layout(3,3,new int[3,3] {{0,0,0},{0,0,0},{0,0,0}});
					if(EI == 0) NewElement.ExtraLayout.Fields[0,0] = 1;
					if(EI == 1) NewElement.ExtraLayout.Fields[0,1] = 1;
					if(EI == 2) NewElement.ExtraLayout.Fields[1,1] = 1;
					if(EI == 3) NewElement.ExtraLayout.Fields[2,2] = 1;
					if(EI == 4) NewElement.ExtraLayout.Fields[2,1] = 1;
				}
				return NewElement;
			}
		}
		return null;
	}
}
