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
		bool CanBuild = this._Floors[this._CurrentFloor].Layout.CanApply(Location, L2);
		if(this._CurrentFloor != 0) CanBuild = CanBuild && this._Floors[this._CurrentFloor - 1].Layout.CanSupport(Location, L2);
		return CanBuild;
	}
	public void Build(Vector2 Location, Element NewElement)
	{
		this._Floors[this._CurrentFloor].Elements.Add(NewElement);
		this._Floors[this._CurrentFloor].Layout.Apply(Location, NewElement.Layout);
	}
	public void GoUp()
	{
		if(this.OnMaxFloor()) this.AddFloor();
		this._CurrentFloor += 1;
	}
	public void GoDown()
	{
		if(this._CurrentFloor != 0) this._CurrentFloor--;
	}
	public bool OnMaxFloor()
	{
		return this._CurrentFloor == this._Floors.Count - 1;
	}
	public void AddFloor()
	{
		Floor NewFloor = new Floor(this._Floors.Count);
		this._Floors.Add(NewFloor);
	}
}
