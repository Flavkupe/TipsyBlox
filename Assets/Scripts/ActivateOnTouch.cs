using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnTouch : MonoBehaviour {

    private Rigidbody2D body;

    public float GravityOnActivate = 1.0f;

    private bool activated = false;

	// Use this for initialization
	void Start () {
        body = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!activated)
        {
            if (col.gameObject.tag == "Block")
            {
                this.Activate();
            }
        }
    }

    protected virtual void Activate()
    {        
        this.body.gravityScale = GravityOnActivate;
        this.activated = true;
    }
}
