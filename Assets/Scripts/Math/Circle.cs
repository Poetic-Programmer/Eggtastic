using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle {
    private Vector2 position;
    private float radius;

	public Circle(Vector2 position, float radius)
    {
        this.position = position;
        this.radius = radius;
    }
}