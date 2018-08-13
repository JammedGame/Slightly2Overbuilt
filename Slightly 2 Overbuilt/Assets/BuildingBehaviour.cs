using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour
{
	public static int PreviewIndex = -1;
	public static BuildingBehaviour Single;
	private int _SelectedIndex;
	private Grid _Grid;
	private Element _Construct;
	private GameObject _ConstructObject;
	private GameObject _Water;
	private GameObject _Ground;
	private Building _Building;
	private Camera _Camera;
	private Preview _Preview;
	void Start ()
	{
		this._SelectedIndex = -1;
		this._Grid = new Grid();
		this._Building = new Building();
		this._Camera = Camera.main;
		this._Preview = new Preview();
		this.CreateGridVisual();
		this.CreateEnvironment();
		BuildingBehaviour.Single = this;
	}
	void Update ()
	{
		CheckBuildingSelected();
		MoveConstructObject();
		CheckPreview();
	}
	private void CreateGridVisual()
	{
		GameObject NewObject = new GameObject("GridObject");
		NewObject.AddComponent<GridBehaviour>();
	}
	private GameObject CreateElement(Vector2 Location, Element Selected)
	{
		GameObject Default;
		Selected.Floor = this._Building.CurrentFloor;
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
			if(this._Construct == null) return;
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
			this._Construct.ConstructAvailable = this._Building.CanBuild(Grid.CursorLocation, this._Construct.Layout);
		}
		else if (Input.GetKeyDown(KeyCode.D) && this._SelectedIndex != -1)
		{
			this._Construct.Rotate(1);
			this._Construct.ConstructAvailable = this._Building.CanBuild(Grid.CursorLocation, this._Construct.Layout);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			this._Building.GoUp();
			this.RepositionCamera();
			this.ChangeSelectedBuilding(this._SelectedIndex);
		}
		else if (Input.GetKeyDown(KeyCode.S))
		{
			this._Building.GoDown();
			this.RepositionCamera();
			this.ChangeSelectedBuilding(this._SelectedIndex);
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
		else if (Input.GetKeyDown(KeyCode.Alpha4) && this._SelectedIndex != 3)
		{
			this.ChangeSelectedBuilding(3);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha5) && this._SelectedIndex != 4)
		{
			this.ChangeSelectedBuilding(4);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha6) && this._SelectedIndex != 5)
		{
			this.ChangeSelectedBuilding(5);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha7) && this._SelectedIndex != 6)
		{
			this.ChangeSelectedBuilding(6);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha8) && this._SelectedIndex != 7)
		{
			this.ChangeSelectedBuilding(7);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9) && this._SelectedIndex != 8)
		{
			this.ChangeSelectedBuilding(8);
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
		if (Input.GetKeyDown(KeyCode.Z))
		{
			this.RotateCamera(1);
		}
		else if (Input.GetKeyDown(KeyCode.C))
		{
			this.RotateCamera(-1);
		}
	}
	public void ChangeSelectedBuilding(int Index)
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
			this._Preview.SetForPreview(this._Construct, this._Building.CurrentFloor);
			this._Construct.Construct = true;
			this._ConstructObject = this.CreateElement(new Vector2(-1,-1), this._Construct);
		}
	}
	private void RepositionCamera()
	{
		Grid.Vertical = this._Building.CurrentFloor;
		this._Camera.transform.position = new Vector3(-9.5f, 8 + this._Building.CurrentFloor * 1.8f, -9.5f);
	}
	private void RotateCamera(int Mult)
	{
		this._Camera.transform.RotateAround(this._Ground.transform.position, new Vector3(0,1,0), Mult*90);
		this._Water.transform.RotateAround(this._Ground.transform.position, new Vector3(0,1,0), Mult*90);
	}
	private void CreateEnvironment()
	{
		GameObject Water = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Water.transform.localScale = new Vector3(100, 10, 20);
		Water.transform.position = new Vector3(0, -6, 0);
		Water.transform.rotation = Quaternion.Euler(0,45,0);
		Water.GetComponent<Renderer>().material.color = new Color(0.2f,0.3f,0.8f,1);
		this._Water = Water;
		GameObject Ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
		Ground.transform.localScale = new Vector3(5.2f * Element.Size, 3, 5.2f * Element.Size);
		Ground.transform.position = new Vector3(0, -1.5f, 0);
		Ground.GetComponent<Renderer>().material.color = new Color(0.6f, 0.6f,0.6f, 1.0f);
		this._Ground = Ground;
	}
	private void CheckPreview()
	{
		if(BuildingBehaviour.PreviewIndex == -1) this._Preview.SetForPreview(null, this._Building.CurrentFloor);
		else this._Preview.SetForPreview(this._Building.Pool.Elements[BuildingBehaviour.PreviewIndex], this._Building.CurrentFloor);
	}
}
