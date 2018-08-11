using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
	private int _SelectedIndex;
	private Grid _Grid;
	private Building _Building;
	void Start ()
	{
		this._SelectedIndex = -1;
		this._Grid = new Grid();
		this._Building = new Building();
		this.CreateGridVisual();
	}
	void Update ()
	{
		CheckBuildingSelected();
	}
	private void CreateGridVisual()
	{
		GameObject NewObject = new GameObject("GridObject");
		NewObject.AddComponent<GridBehaviour>();
	}
	private void CreateElement(Element New, Vector2 Location)
	{
		Debug.Log(Location);
		Element.Current = New;
		Element.Current.Location = Location;
		GameObject NewObject = new GameObject("ElementObject");
		NewObject.AddComponent<ElementBehaviour>();
	}
	private void CheckBuildingSelected()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Grid.Visible = true;
			this._SelectedIndex = 0;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Grid.Visible = true;
			this._SelectedIndex = 1;
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			Grid.Visible = false;
			this._SelectedIndex = -1;
		}
		else if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			if(this._SelectedIndex != -1 && Grid.CursorLocation.x != -1) this.CreateElement(this._Building.Pool.Elements[this._SelectedIndex], Grid.CursorLocation);
			Grid.Visible = false;
			this._SelectedIndex = -1;
		}
	}
}
