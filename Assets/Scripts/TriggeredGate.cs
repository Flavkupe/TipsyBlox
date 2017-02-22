using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeredGate : MonoBehaviour {

    public RotateAroundPivot[] RotatingPieces;

    public GateType Type = GateType.KeyActivated;

    public Rigidbody2D LockObject;

    public float MassReq;

    private float massCount = 0;

    private bool activated = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (Type == GateType.WeightActivated)
        {
            Rigidbody2D otherBody = other.GetComponent<Rigidbody2D>();
            if (otherBody != null && otherBody.gravityScale > 0)
            {
                massCount -= otherBody.mass;                
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
        {
            return;
        }

        if (Type == GateType.KeyActivated && other.tag == "Key")
        {
            this.ActivateGate();
        }
        else if (Type == GateType.WeightActivated)
        {
            Rigidbody2D otherBody = other.GetComponent<Rigidbody2D>();
            if (otherBody != null && otherBody.gravityScale > 0)
            {
                massCount += otherBody.mass;
                if (massCount >= this.MassReq)
                {
                    this.ActivateGate();
                }
            } 
        }
    }

    protected virtual void ActivateGate()
    {
        if (activated)
        {
            return;
        }

        activated = true;

        if (this.RotatingPieces != null)
        {
            foreach (RotateAroundPivot piece in this.RotatingPieces)
            {
                piece.DoRotation();
            }
        }

        if (this.LockObject != null)
        {
            this.LockObject.gravityScale = 1;
        }
    }
}

public enum GateType
{
    KeyActivated,
    WeightActivated
}
