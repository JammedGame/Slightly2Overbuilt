using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
	private int _SelectedIndex;
	private Building _Building;
	void Start ()
	{
		this._SelectedIndex = -1;
		this._Building = new Building();
	}
	void Update ()
	{
		CheckBuildingSelected();
	}
	private void CreateElement(Element New)
	{
		Element.Current = New;
		GameObject NewObject = new GameObject("ElementObject");
		NewObject.AddComponent<ElementBehaviour>();
	}
	private void CheckBuildingSelected()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			this._SelectedIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			this._SelectedIndex = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(this._SelectedIndex != -1) this.CreateElement(this._Building.Pool.Elements[this._SelectedIndex]);
		}
	}
}
