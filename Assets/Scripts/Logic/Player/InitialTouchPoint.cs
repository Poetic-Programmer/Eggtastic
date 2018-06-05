using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTouchPoint {
    bool isTouched;
    Vector2 position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isTouched)
        {
            if(Input.GetMouseButtonDown(0))
            {
                position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                var ray = Physics2D.Raycast(position, Vector2.up);
                if(ray)
                {
                   
                }
            }
        }
	}
}
