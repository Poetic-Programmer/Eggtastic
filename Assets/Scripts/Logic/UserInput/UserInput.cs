using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour {
    public LayerMask collisionMask;
    public float collisionRadius = 0.1f;

    private RawUserInput inputInfo;
    private InputSpriteSelector spriteSelector;
    private InputCollider inputCollider;
    private Vector2 inputAnchorPoint;
    private GrabPullBehaviour grabPullBehaviour;
    private Transform hitObjectTransform;
    private Vector2 objectAnchor;

	// Use this for initialization
	void Start () {
        inputInfo = GetInputType();
        spriteSelector = new InputSpriteSelector(
            gameObject.GetComponent<SpriteRenderer>(),
            Resources.LoadAll<Sprite>("debug_circles"));
        inputCollider = new InputCollider(collisionRadius, collisionMask);
        inputAnchorPoint = new Vector2();
        grabPullBehaviour = new GrabPullBehaviour();
        objectAnchor = new Vector2();
	}
	
	// Update is called once per frame
	void Update () {
        if (inputInfo.IsPressed())
        {
            inputInfo.CapturePositionVelocity();
            transform.position = inputInfo.GetPosition();
            inputCollider.CheckForCollisions(transform.position, collisionRadius);

            switch (inputCollider.GetState())
            {
                case InputColliderState.IDLE:
                    spriteSelector.FlipPressed();
                    if(grabPullBehaviour.IsGrabbed())
                    {
                        if (!inputInfo.IsPressed())
                        {
                            grabPullBehaviour.Release();
                        }   
                    }
                    break;
                case InputColliderState.HIT:
                    Debug.Log("HIT");
                    spriteSelector.FlipColliding();
                    
                    if (inputCollider.IsFirstHit())
                    {
                        inputAnchorPoint = transform.position;
                        objectAnchor = inputCollider.GetHitObjectTransform().position;
                        hitObjectTransform = inputCollider.GetHitObjectTransform();
                        grabPullBehaviour.Grab();  
                    }
                    break;
            }
        }
        else
        {
            inputCollider.Release();
            grabPullBehaviour.Release();
        }

        if (grabPullBehaviour.IsGrabbed())
        {
            var difference = inputInfo.GetPosition() - inputAnchorPoint;
            var objectPos = hitObjectTransform.position;
            hitObjectTransform.position = new Vector3(
                objectAnchor.x + difference.x, objectAnchor.y + difference.y, objectPos.z);
        }
    }

    private RawUserInput GetInputType()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return new RawAndroidUserInput();
        }
        else
        {
            return new RawPCUserInput();
        }
    }
}
