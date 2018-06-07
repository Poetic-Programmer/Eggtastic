using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The wind will get stronger as the game progresses. The increments
 * will be steady at around 30secs. the transition from one speed to
 * another should last no more than 10secs
 */

public class WindVelocitySelector {
    private const float TIME_TO_WIND_CHANGE = 30;
    private const float TIME_FOR_TRANSITION = 10;

    private WindState windState;
    private WindAnimationState windAnimationState;

    private float windChangeTimer;
    private float windTransitionTimer;

    private float windSpeed;
    private float previousWindSpeed;
    private float targetWindSpeed;
    private float windTransitionVariable;
    private float testTimer;
    public WindVelocitySelector()
    {
        windState = WindState.CALM;
        windAnimationState = WindAnimationState.IDLE;
        windSpeed = GetNewSpeed();
    }

    public void Update()
    {
        windChangeTimer += Time.deltaTime;
        if(windChangeTimer >= TIME_TO_WIND_CHANGE)
        {
            windState = GetNext(windState);
            windAnimationState = WindAnimationState.TRANSITIONING;
            windChangeTimer = 0;

            targetWindSpeed = GetNewSpeed();
            windTransitionVariable = (targetWindSpeed - windSpeed) / TIME_FOR_TRANSITION;
            testTimer = 0;
        }

        if(windAnimationState == WindAnimationState.TRANSITIONING)
        {
            windSpeed += windTransitionVariable * Time.deltaTime;
            testTimer += Time.deltaTime;
            if((Mathf.Abs(windSpeed) >= Mathf.Abs(targetWindSpeed)))
            {
                windSpeed = targetWindSpeed;
                windAnimationState = WindAnimationState.IDLE;
            }
        }
    }
    public float GetSpeed() { return windSpeed; }
    private float GetNewSpeed()
    {
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
                minSpeed = windSpeed;
                maxSpeed = windSpeed;
                break;
        }
        var speed = Random.Range(minSpeed, maxSpeed);
        if(Random.value < 0.5f)
        {
            speed *= -1;
        }
        return speed;
    }
    WindState GetNext(WindState current)
    {
        var state = current;
        switch (current)
        {
            case WindState.CALM:
                state = WindState.LIGHT_AIR;
                break;
            case WindState.LIGHT_AIR:
                state = WindState.LIGHT_BREEZE;
                break;
            case WindState.LIGHT_BREEZE:
                state = WindState.GENTLE_BREEZE;
                break;
            case WindState.GENTLE_BREEZE:
                state = WindState.MODERATE_BREEZE;
                break;
            case WindState.MODERATE_BREEZE:
                state = WindState.FRESH_BREEZE;
                break;
            case WindState.FRESH_BREEZE:
                state = WindState.STRONG_BREEZE;
                break;
            case WindState.STRONG_BREEZE:
                state = WindState.HIGH_WIND;
                break;
            case WindState.HIGH_WIND:
                state = WindState.GALE;
                break;
            case WindState.GALE:
                state = WindState.STRONG_GALE;
                break;
            case WindState.STRONG_GALE:
                state = WindState.STORM;
                break;
            case WindState.STORM:
                state = WindState.VIOLENT_STORM;
                break;
            case WindState.VIOLENT_STORM:
                state = WindState.HURRICANE_FORCE;
                break;
            case WindState.HURRICANE_FORCE:
                break;
        }
        return state;
    }
}
