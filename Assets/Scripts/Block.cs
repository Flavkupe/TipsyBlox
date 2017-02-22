using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public BlockShape Shape;

    public BlockColor Color;    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Match()
    {
        LevelManager.Instance.MatchBlock(this);
        StartCoroutine(this.Shrink());
        Destroy(this.gameObject, 0.3f);
    }

    private IEnumerator Shrink()
    {
        while (this.gameObject != null && this.transform.localScale.x > 0.0)
        {
            if (this.gameObject != null)
            {
                this.transform.localScale *= 0.98f;                    
            }

            yield return null;
        }
    }
}

public enum BlockShape
{
    Triangle,
    Box,
    Circle
}

public enum BlockColor
{
    Red,
    Blue,
    Green,
    Yellow,
    None
}