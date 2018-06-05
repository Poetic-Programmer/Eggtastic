using UnityEngine;

[RequireComponent(typeof(LayerMask))]

public class InputCollider {
    public LayerMask collisionMask;
    public int NumberOfHorizontalRays = 4;
    private float colliderRadius;
    private InputColliderState state;
    private bool firstHit;
    private bool hitCounter;
    private RaycastHit2D hitInfo;
    public InputCollider(float colliderRadius, LayerMask collisionMask)
    {
        this.colliderRadius = colliderRadius;
        this.collisionMask = collisionMask;

        state = InputColliderState.IDLE;
        firstHit = false;
        hitCounter = false;
    }

    public void CheckForCollisions(Vector2 position, float debugRadius)
    {
        hitInfo = Physics2D.Raycast(position, Vector2.up, debugRadius, collisionMask);

        if(hitInfo)
        {
            state = InputColliderState.HIT;
            if (!hitCounter && !firstHit)
            {
                firstHit = true;
            }
            else
            {
                firstHit = false;
            }
            hitCounter = true;
        }
        else
        {
            state = InputColliderState.IDLE;
            hitCounter = false;
            firstHit = false;
        }

        Debug.DrawRay(position, Vector2.up * debugRadius, Color.red);
    }

    public InputColliderState GetState()
    {
        return state;
    }
    public bool IsFirstHit()
    {
        return firstHit;
    }
    public void Release()
    {
        firstHit = false;
        hitCounter = false;
        state = InputColliderState.IDLE;
    }
    public Transform GetHitObjectTransform()
    {
        return hitInfo.transform;
    }
}
