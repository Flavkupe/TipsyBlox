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
        Destroy(this.gameObject);
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