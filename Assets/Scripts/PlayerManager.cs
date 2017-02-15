using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public int CurrentLevel = 1;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
