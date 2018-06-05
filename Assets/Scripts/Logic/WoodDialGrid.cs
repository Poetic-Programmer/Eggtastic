using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDialGrid : MonoBehaviour {
    public GameObject WoodDial;

    private int NumberOfHorizontalDials = 5;
    private int NumberOfVerticalDials = 5;

    public float GamePlayWidth = 25;
    public float GamePlayHeight = 15;

	// Use this for initialization
	void Start () {
        var startXPosition = 0;
        var horizontalSpaceBetween = GamePlayWidth / NumberOfHorizontalDials;
        var startYPosition = 5;
        var verticalSpaceBetween = GamePlayHeight / NumberOfVerticalDials;

        for(int i = 0; i <= NumberOfHorizontalDials; ++i)
        {
            var xpos = startXPosition + (i * horizontalSpaceBetween);
            for(int j = 0; j <= NumberOfVerticalDials; ++j)
            {
                var ypos = startYPosition - (j * verticalSpaceBetween);
                Vector3 position = new Vector3(
                        xpos, ypos, 0
                    );
               
                //GameObject woodDial = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                var t = Instantiate(WoodDial);
                t.gameObject.transform.position = position;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
