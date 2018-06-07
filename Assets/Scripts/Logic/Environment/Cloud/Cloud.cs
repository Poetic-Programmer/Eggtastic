using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {
    public Rigidbody2D rb;
    Vector2 force;
    Vector2 velocity;
    private float minMass = 20;
    private float maxMass = 50;
    private float mass;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mass = Random.Range(minMass, maxMass);
        transform.localScale = new Vector3(mass / 50, mass / 50, 0);
    }

    void FixedUpdate()
    {
        velocity = new Vector2(Wind.WindSpeed / mass * Time.deltaTime, 0);
        var currentPosition = transform.position;
        transform.position = new Vector3(
            (currentPosition.x + velocity.x),
            currentPosition.y, 
            currentPosition.z);
    }
}
