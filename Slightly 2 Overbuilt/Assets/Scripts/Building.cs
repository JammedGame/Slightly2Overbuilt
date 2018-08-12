using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
	private int _CurrentFloor;
	private Store _Pool;
	private List<Floor> _Floors;
	public int CurrentFloor
	{
		get { return this._CurrentFloor; }
		set { this._CurrentFloor = value; }
	}
	public Store Pool
	{
		get { return this._Pool; }
		set { this._Pool = value; }
	}
	public List<Floor> Floors
	{
		get { return this._Floors; }
		set { this._Floors = value; }
	}
	public Building()
	{
		this._Pool = new Store();
		this._Floors = new List<Floor>();
		Floor NewFloor = new Floor(0);
		this._Floors.Add(NewFloor);
		this._CurrentFloor = 0;
	}
	public bool CanBuild(Vector2 Location, Layout L2)
	{
		return this._Floors[this._CurrentFloor].Layout.CanApply(Location, L2);
	}
	public void Build(Vector2 Location, Element NewElement)
	{
		this._Floors[this._CurrentFloor].Elements.Add(NewElement);
		this._Floors[this._CurrentFloor].Layout.Apply(Location, NewElement.Layout);
	}
}
