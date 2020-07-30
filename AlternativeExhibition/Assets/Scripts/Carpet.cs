using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The following class immitates JSON in the sense that the 


public class Carpet 

{
	//as the name suggests, these are the values to scale in the x and z direction

	
	
	private float xScale;  
	private float zScale;
	private string URL;

	public Carpet(string url,float scaleInX, float scaleInZ) // these can be seen as the length and breadth
	{
		xScale = scaleInX;
		zScale = scaleInZ;
		URL = url;
	}

	public string getURL()
	{
		return URL;
	}

	public float getX()
	{
		return xScale;
	}

	public float getZ()
	{
		return zScale;
	}
}
