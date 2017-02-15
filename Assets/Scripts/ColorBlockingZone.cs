using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlockingZone : Zone
{    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void InitZone()
    {
        base.InitZone();

        foreach(Block block in LevelManager.Instance.Blocks)
        {
            if (block.Color == this.Color)
            {
                Physics2D.IgnoreCollision(block.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            }
        }
    }
}
