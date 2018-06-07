using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCover {
    private float minX, maxX;
    private float minY, maxY;

	// Use this for initialization
	public CloudCover() {
        minX = -10;
        maxX = 10;

        minY = -2;
        maxY = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float GetMinX() { return minX; }
    public float GetMaxX() { return maxX; }
    public float GetMinY() { return minY; }
    public float GetMaxY() { return maxY; }
}
