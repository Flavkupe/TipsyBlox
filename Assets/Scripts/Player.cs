using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Public fields that we can set in the inspector to configure the player
    public float MoveSpeed = 0.05f;
    public float JumpStrength = 5.0f;

    // Use this for initialization
    void Start () {		
	}
	
	// Update is called once per frame
	void Update () {

        // If we detect that the Left Arrow key is pressed down...
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            // ... we move left by whatever "MoveSpeed" is.
            this.MoveLeft(MoveSpeed);
        }

        // If we detect that the Right Arrow key is pressed down...
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // ... we move right by whatever "MoveSpeed" is
            this.MoveRight(MoveSpeed);
        }

        // The moment we detect the Space key go down...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ... we apply a force upwards. The strength of the force is JumpStrength.
            this.ApplyForceUp(JumpStrength);
        }

        // If the Player's Y position is less than -10.0...
        if (this.GetPosY() < -10.0f)
        {
            // ... we teleport to (0,0)
            this.Goto(0, 0);
        }
    }
}
