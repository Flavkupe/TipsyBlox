using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotato : MonoBehaviour {

    public Camera cam;

    public float RotationAngleMax = 1.0f;

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;

        //StartCoroutine(LogGyro());
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Physics2D.gravity = Input.gyro.gravity * 9.81f;

        //Can't make this work well...
        //Quaternion gravDirection = Quaternion.LookRotation(Input.gyro.gravity * -1, Vector3.up);
        //Vector3 target = gravDirection.eulerAngles;
        //target = Utils.ClampAngle(target, -RotationAngleMax, RotationAngleMax);        
        //Vector3 v = Vector3.Lerp(this.cam.transform.eulerAngles, target, 0.1f);
        //this.cam.transform.eulerAngles = Utils.ClampAngle(target, -RotationAngleMax, RotationAngleMax);
    }

    void Update()
    {
        
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
