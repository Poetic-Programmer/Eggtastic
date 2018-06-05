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
        windState = WindState.CALM;

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
        var minSpeed = 0.0f;
        var maxSpeed = 0.0f;
        switch (windState)
        {
            case WindState.CALM:
                minSpeed = 0.0f;
                maxSpeed = 0.3f;
                break;
            case WindState.LIGHT_AIR:
                minSpeed = 1.0f;
                maxSpeed = 3.0f;
                break;
            case WindState.LIGHT_BREEZE:
                minSpeed = 4.0f;
                maxSpeed = 7.0f;
                break;
            case WindState.GENTLE_BREEZE:
                minSpeed = 8.0f;
                maxSpeed = 12.0f;
                break;
            case WindState.MODERATE_BREEZE:
                minSpeed = 13.0f;
                maxSpeed = 18.0f;
                break;
            case WindState.FRESH_BREEZE:
                minSpeed = 19.0f;
                maxSpeed = 24.0f;
                break;
            case WindState.STRONG_BREEZE:
                minSpeed = 25.0f;
                maxSpeed = 31.0f;
                break;
            case WindState.HIGH_WIND:
                minSpeed = 32.0f;
                maxSpeed = 38.0f;
                break;
            case WindState.GALE:
                minSpeed = 39.0f;
                maxSpeed = 46.0f;
                break;
            case WindState.STRONG_GALE:
                minSpeed = 47.0f;
                maxSpeed = 54.0f;
                break;
            case WindState.STORM:
                minSpeed = 55.0f;
                maxSpeed = 63.0f;
                break;
            case WindState.VIOLENT_STORM:
                minSpeed = 64.0f;
                maxSpeed = 72.0f;
                break;
            case WindState.HURRICANE_FORCE:
                minSpeed = 73.0f;
                maxSpeed = 81.0f;
                break;
        }
        return state;
    }
}
