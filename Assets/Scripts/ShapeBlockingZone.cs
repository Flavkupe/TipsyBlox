using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBlockingZone : Zone {

    public BlockShape Shape;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void InitZone()
    {
        base.InitZone();

        foreach (Block block in LevelManager.Instance.Blocks)
        {
            if (block.Shape == this.Shape)
            {
                Physics2D.IgnoreCollision(block.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            }
        }
    }
}
