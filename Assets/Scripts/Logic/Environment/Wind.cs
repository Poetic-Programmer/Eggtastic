using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind {
    WindState windState;

    private const float MIN_TIME_TO_CHANGE = 12;
    private const float MAX_TIME_TO_CHANGE = 30;
    private float timeToChange;
    private Vector2 velocity;
    private float timer;
    bool transitioning;
	// Use this for initialization
	public Wind () {
        windState = WindState.LIGHT;

        velocity = new Vector2();

        timeToChange = GetTimeToChange();

        transitioning = false;
	}
	
	// Update is called once per frame
	public void Blow () {
        timer += Time.deltaTime;

        if (timer >= timeToChange)
        {
            timer = 0;
            timeToChange = GetTimeToChange();
            windState = GetWindState();
        }
	}

    public Vector2 GetVelocity()
    {
        return velocity;
    }
    private float GetTimeToChange()
    {
        return Random.Range(MIN_TIME_TO_CHANGE, MAX_TIME_TO_CHANGE);
    }
    private WindState GetWindState()
    {
        var state = windState;

        int roll = Random.Range(0, 10);
        switch(roll)
        {
            case 0:
                state = WindState.HEAVY_FAST;
                velocity.x = -10;
                break;
            case 1:
                state = WindState.HEAVY;
                velocity.x = -10;
                break;
            case 2:
                state = WindState.MEDIUM_FAST;
                velocity.x = -10;
                break;
            case 3:
                state = WindState.MEDIUM;
                velocity.x = -10;
                break;
            case 4:
                state = WindState.LIGHT_FAST;
                velocity.x = -10;
                break;
            case 5:
                state = WindState.LIGHT;
                velocity.x = -10;
                break;
        }

        return state;
    }
}
