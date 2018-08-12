using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
	private int _SelectedIndex;
	private Grid _Grid;
	private Element _Construct;
	private GameObject _ConstructObject;
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
		MoveConstructObject();
	}
	private void CreateGridVisual()
	{
		GameObject NewObject = new GameObject("GridObject");
		NewObject.AddComponent<GridBehaviour>();
	}
	private GameObject CreateElement(Vector2 Location, Element Selected)
	{
		Element.Current = Selected;
		Element.Current.Location = Location;
		GameObject NewObject = new GameObject("ElementObject");
		NewObject.AddComponent<ElementBehaviour>();
		return NewObject;
	}
	private void MoveConstructObject()
	{
		if(this._SelectedIndex != -1)
		{
			if(this._Construct.Location.x != Grid.CursorLocation.x || this._Construct.Location.y != Grid.CursorLocation.y)
			{
				this._Construct.ConstructAvailable = this._Building.CanBuild(Grid.CursorLocation, this._Construct.Layout);
				this._Construct.Location = Grid.CursorLocation;
			}
		}
	}
	private void CheckBuildingSelected()
	{
		if (Input.GetKeyDown(KeyCode.A) && this._SelectedIndex != -1)
		{
			this._Construct.Rotate(-1);
		}
		else if (Input.GetKeyDown(KeyCode.D) && this._SelectedIndex != -1)
		{
			this._Construct.Rotate(1);
		}
		if (Input.GetKeyDown(KeyCode.Alpha1) && this._SelectedIndex != 0)
		{
			this.ChangeSelectedBuilding(0);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2) && this._SelectedIndex != 1)
		{
			this.ChangeSelectedBuilding(1);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3) && this._SelectedIndex != 2)
		{
			this.ChangeSelectedBuilding(2);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha0) && this._SelectedIndex != -1)
		{
			this.ChangeSelectedBuilding(-1);
		}
		if (Input.GetKeyDown(KeyCode.Mouse0) && Grid.CursorLocation.x != -1)
		{
			if(this._SelectedIndex != -1)
			{
				if(this._Building.CanBuild(Grid.CursorLocation, this._Construct.Layout))
				{
					Element NewElement = this._Construct.Copy();
					this._Building.Build(Grid.CursorLocation, NewElement);
					this.CreateElement(Grid.CursorLocation, NewElement);
					this.ChangeSelectedBuilding(-1);
				}
			}
		}
	}
	private void ChangeSelectedBuilding(int Index)
	{
		this._SelectedIndex = Index;
		if(this._Construct != null)
		{
			this._Construct.Destroy();
		}
		if(this._SelectedIndex == -1)
		{
			Grid.Visible = false;
			this._Construct = null;
			this._ConstructObject = null;
		}
		else 
		{
			Grid.Visible = true;
			this._Construct = this._Building.Pool.Elements[this._SelectedIndex].Copy();
			this._Construct.Construct = true;
			this._ConstructObject = this.CreateElement(new Vector2(-1,-1), this._Construct);
		}
	}
}
