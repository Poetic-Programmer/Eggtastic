using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    private const float MIN_MASS = 1;
    private const float MAX_MASS = 5;
    float mass;

    private Vector2 velocity;
    float windSpeed;

    CloudSpriteSelector spriteSelector;
	// Use this for initialization
	void Start () {
        spriteSelector = new CloudSpriteSelector(
            gameObject.GetComponent<SpriteRenderer>(),
            Resources.LoadAll<Sprite>("clouds"));
        mass = Random.Range(MIN_MASS, MAX_MASS);
        windSpeed = -1;
        velocity = new Vector2(mass * windSpeed, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector2(
            transform.position.x + (velocity.x * Time.deltaTime),
            transform.position.y);

        if (transform.position.x <= -20)
        {
            transform.position = new Vector2(20, transform.position.y);
            spriteSelector.SelectNew();
        }
	}
}
