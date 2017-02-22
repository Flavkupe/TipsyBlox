using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour {    

    public BlockColor Color;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Block block = other.transform.GetComponent<Block>();
        if (block != null)
        {
            if (block.Color == this.Color)
            {
                block.Match();
            }
        }               
    }

    public virtual void InitZone()
    {
    }
}
