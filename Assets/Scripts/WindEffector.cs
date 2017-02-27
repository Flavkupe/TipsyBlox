using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffector : MonoBehaviour {

    public float Force = 10.0f;

    public Transform MaxDistanceMarker;

    private float maxDistance;

	// Use this for initialization
	void Start () {
        maxDistance = Vector3.Distance(this.transform.position, MaxDistanceMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D other)
    {                    
        Rigidbody2D body = other.GetComponent<Rigidbody2D>();
        if (body != null)
        {            
            Vector3 direction = other.transform.position - this.transform.position;                       
            float distance = Vector3.Distance(other.transform.position, this.transform.position);
            float percentDiff = Mathf.Min(1.0f, distance / maxDistance);
            int mask = 1 << LayerMask.NameToLayer("StaticObstacle") | 1 << LayerMask.NameToLayer("Block") | 1 << LayerMask.NameToLayer("MovingObstacle");
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, direction, distance, mask);
            if (hit.collider != null && hit.collider.tag == "StaticObstacle")
            {
                return;
            }

            Vector3 forceVector = direction.normalized * this.Force * percentDiff;
            body.AddForce(forceVector, ForceMode2D.Force);
        }
    }
}
