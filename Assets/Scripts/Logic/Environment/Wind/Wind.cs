using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour{
    public static float WindSpeed;

    WindState windState;

    private const float MIN_TIME_TO_CHANGE = 12;
    private const float MAX_TIME_TO_CHANGE = 30;
    private float timeToChange;
    
    private float timer;
    bool transitioning;
    private WindVelocitySelector windVelocitySelector;

	void Start () {
        windVelocitySelector = new WindVelocitySelector();
	}
	
    void Update()
    {
        windVelocitySelector.Update();
        WindSpeed = windVelocitySelector.GetSpeed();
        Debug.Log("WIND SPEED: " + WindSpeed);
    }
}
