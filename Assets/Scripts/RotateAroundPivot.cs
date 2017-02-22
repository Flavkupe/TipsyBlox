using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundPivot : MonoBehaviour {

    public GameObject Pivot;

    public float Angle = 90.0f;

    public float Speed = 2.0f;

	// Use this for initialization
	void Start () {
    }
	
    public void DoRotation()
    {
        StartCoroutine(RotateOverTime());
    }

    private IEnumerator RotateOverTime()
    {
        float totalCovered = 0.0f;
        while (totalCovered < Angle)
        {
            float rotationAngle = Time.deltaTime * Speed;
            totalCovered += Mathf.Abs(rotationAngle);
            this.transform.RotateAround(Pivot.transform.position, Vector3.forward, rotationAngle);
            yield return null;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
