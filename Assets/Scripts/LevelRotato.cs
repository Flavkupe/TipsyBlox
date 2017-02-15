using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotato : MonoBehaviour {

    public Camera cam;

	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;

        StartCoroutine(LogGyro());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Physics2D.gravity = Input.gyro.gravity * 9.81f;
    }

    private IEnumerator LogGyro()
    {
        while (true)
        {
            
            Debug.Log("Attitude: " + Input.gyro.attitude);

            float angle;
            Vector3 axis;
            Input.gyro.attitude.ToAngleAxis(out angle, out axis);
            Debug.Log("Angle: " + angle);
            Debug.Log("Axis: " + axis);

            yield return new WaitForSeconds(3);
        }
    }
}
