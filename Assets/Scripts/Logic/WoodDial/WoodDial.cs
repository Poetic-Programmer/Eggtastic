using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDial : MonoBehaviour {
    static int count = 0;
    static Sprite[] sprite;
    private Circle movementCircle;

    // Use this for initialization
    void Start() {
        count++;
        Debug.Log("Lets count: " + count);
        int index = Random.Range(0, 4);

        if (count <= 1) { 
            sprite = Resources.LoadAll<Sprite>("dials1024");
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite[index];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
