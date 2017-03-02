using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLockZoneTrigger : MonoBehaviour {

    public ColorLockZone[] Zones;

    public BlockColor Color;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        Block block = collider.GetComponent<Block>();
        if (block != null && block.Color == this.Color)
        {
            ToggleZones(true);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Block block = collider.GetComponent<Block>();
        if (block != null && block.Color == this.Color)
        {
            ToggleZones(false);
        }
    }

    private void ToggleZones(bool open)
    {
        if (this.Zones != null && this.Zones.Length > 0)
        {
            foreach (ColorLockZone zone in this.Zones)
            {
                zone.SetOpen(open);
            }
        }
    }
    
}
