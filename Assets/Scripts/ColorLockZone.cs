using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLockZone : ColorBlockingZone
{

    public void SetOpen(bool open)
    {
        boundingBox.isTrigger = open;
        EnabledMeshes.SetActive(!open);
        DisabledMeshes.SetActive(open);
    }

    public GameObject EnabledMeshes;
    public GameObject DisabledMeshes;

    public Collider2D boundingBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
