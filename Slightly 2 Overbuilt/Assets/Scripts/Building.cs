using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building
{
	private Store _Pool;
	private Floor _Current;
	private List<Floor> _Floors;
	public Store Pool
	{
		get { return this._Pool; }
		set { this._Pool = value; }
	}
	public Floor Current
	{
		get { return this._Current; }
		set { this._Current = value; }
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
		this._Current = new Floor(0);
		this._Floors.Add(this._Current);
	}
}
