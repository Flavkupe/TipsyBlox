using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUICanvas : Singleton<LevelUICanvas>
{  
    public GameObject EndLevelMenu;

    public Text TimerText;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();
    }

    public void ResetLevel()
    {
        LevelManager.Instance.ResetLevel();        
    }
}
