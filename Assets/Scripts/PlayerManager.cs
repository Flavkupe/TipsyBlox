using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public int CurrentLevel = 1;

    public int MaxLevel = 0;

    public Dictionary<int, int> LevelScores = new Dictionary<int, int>();
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }    
	
	// Update is called once per frame
	void Update ()
    {		
	}

    public void DeleteProgress()
    {
        // TODO
    }
}
