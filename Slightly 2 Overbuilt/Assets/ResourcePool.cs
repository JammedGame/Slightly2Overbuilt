using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePool
{
	public static ResourcePool Single;
	public List<bool> Done;
	public List<int[]> Reqs;
	public ResourcePool()
	{
		this.Done = new List<bool>();
		for(int i = 0; i < 13; i++) this.Done.Add(false);
		this.Reqs = new List<int[]>();
		this.Reqs.Add(new int[1]{1});
		this.Reqs.Add(new int[1]{0});
		this.Reqs.Add(new int[1]{2});
		this.Reqs.Add(new int[1]{0});
		this.Reqs.Add(new int[2]{6,4});
		this.Reqs.Add(new int[2]{3,6});
		this.Reqs.Add(new int[2]{2,5});
		this.Reqs.Add(new int[3]{9,7,8});
		this.Reqs.Add(new int[3]{8,0,9});
		this.Reqs.Add(new int[3]{9,10,11});
		ResourcePool.Single = this;
	}
	public void Do(int Index)
	{
		if(Index == 12) BuildingBehaviour.Single.WinGame();
		this.Done[Index] = true;
	}
	public void Undo(int Index)
	{
		this.Done[Index] = false;
	}
	public bool IsDone(int Index)
	{
		return this.Done[Index];
	}
	public int[] GetReqs(int Index)
	{
		if(Index < 3) return null;
		Index -= 3;
		return this.Reqs[Index];
	}
	public bool AreReqsMet(int Index)
	{
		int[] Reqs = this.GetReqs(Index);
		if(Reqs == null) return true;
		for(int i =0; i < Reqs.Length; i++)
		{
			if(!this.IsDone(Reqs[i])) return false;
		}
		return true;
	}
	public void UndoReqs(int Index)
	{
		int[] Reqs = this.GetReqs(Index);
		if(Reqs == null) return;
		for(int i =0; i < Reqs.Length; i++)
		{
			this.Undo(Reqs[i]);
		}
	}
}
