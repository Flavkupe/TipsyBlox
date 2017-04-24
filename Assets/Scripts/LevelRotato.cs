using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelRotato : MonoBehaviour {

    public Camera cam;

    public float RotationAngleMax = 1.0f;

    private List<Rigidbody2D> bodies;

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;

        //StartCoroutine(LogGyro());

        this.bodies = GameObject.FindObjectsOfType<Rigidbody2D>().ToList();
            
    }

    public float ShakeShreshold = 0.3f; 

    private float lastAccel = 1.0f;

    private float shakeCooldown = 0.0f;

	// Update is called once per frame
	void FixedUpdate ()
    {
        Physics2D.gravity = Input.gyro.gravity * 9.81f;

        if (shakeCooldown <= 0.0f)
        {
            float accel = Input.acceleration.magnitude;
            if (accel - lastAccel > this.ShakeShreshold)
            {
                shakeCooldown = 1.0f;
                foreach (Rigidbody2D body in this.bodies.ToList())
                {
                    if (body == null)
                    {
                        bodies.Remove(body);
                        continue;
                    }

                    if (body.gravityScale != 0)
                    {
                        Debug.Log("Shake!");
                        body.AddForce(Input.acceleration, ForceMode2D.Impulse);
                    }
                }
            }

            lastAccel = accel;
        }         

        //Can't make this work well...
        //Quaternion gravDirection = Quaternion.LookRotation(Input.gyro.gravity * -1, Vector3.up);
        //Vector3 target = gravDirection.eulerAngles;
        //target = Utils.ClampAngle(target, -RotationAngleMax, RotationAngleMax);        
        //Vector3 v = Vector3.Lerp(this.cam.transform.eulerAngles, target, 0.1f);
        //this.cam.transform.eulerAngles = Utils.ClampAngle(target, -RotationAngleMax, RotationAngleMax);
    }

    void Update()
    {
        if (shakeCooldown > 0.0f)
        {
            shakeCooldown -= Time.deltaTime;                
        }
    }

    private IEnumerator LogGyro()
    {
        while (true)
        {
            
            Debug.Log("Gravity: " + Input.gyro.gravity);            
            yield return new WaitForSeconds(3);
        }
    }
}
