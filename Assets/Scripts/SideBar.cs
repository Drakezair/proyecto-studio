using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SideBar : MonoBehaviour {

	public MeshRenderer bg;
	
	void Start ()
	{
	
	}
		
	void Update ()
	{
	
		bg.material.mainTextureOffset = new Vector2(0.05f*Time.time,0);

	}
}
