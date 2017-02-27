using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotato : MonoBehaviour {

    public float RotatoSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.forward, RotatoSpeed);
	}
}
