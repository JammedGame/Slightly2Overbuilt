using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResIndicatorBehaviour : MonoBehaviour
{
	private List<Texture> _Textures;
	private int _LastIndex;
	void Start ()
	{
		this._LastIndex = -1;
		this.InitTextures();
		gameObject.transform.position = new Vector3(0, -100, 0);
	}
	void Update ()
	{
		if(BuildingBehaviour.PreviewIndex != this._LastIndex)
		{
			this.CheckStatus();
		}
	}
	public void CheckStatus()
	{
        int index = int.Parse(gameObject.tag);
        int SelIndex = BuildingBehaviour.PreviewIndex;
		this._LastIndex = SelIndex;
        if(SelIndex == -1)
        {
            gameObject.transform.position = new Vector3(0, -100, 0);
            return;
        }
        int [] Reqs = ResourcePool.Single.GetReqs(SelIndex);
        /*if(Reqs == null) Debug.Log(Reqs);
        else Debug.Log("["+Reqs[0]+","+((Reqs.Length > 1)?(Reqs[1]+""):"")+","+((Reqs.Length > 2)?(Reqs[2]+""):"")+"]");*/
        if(Reqs != null && Reqs.Length > index)
        {
            gameObject.transform.position = new Vector3(150 + index * 35, 60, 0);
            gameObject.GetComponent<RawImage>().texture = this._Textures[Reqs[index]];
            if(ResourcePool.Single.IsDone(Reqs[index])) gameObject.GetComponent<RawImage>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            else gameObject.GetComponent<RawImage>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
        }
        else gameObject.transform.position = new Vector3(0, -100, 0);
    }
    private void InitTextures()
    {
        this._Textures = new List<Texture>();
        Texture tex = Resources.Load("voda") as Texture;
        this._Textures.Add(tex);
        tex = Resources.Load("hrana") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("gorivo") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("tekstil") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("drvo") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("metal") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("staklo") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("guma") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("plastika") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("struja") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("elektronika") as Texture2D;
        this._Textures.Add(tex);
        tex = Resources.Load("farmaceutika") as Texture2D;
        this._Textures.Add(tex);
    }
}
