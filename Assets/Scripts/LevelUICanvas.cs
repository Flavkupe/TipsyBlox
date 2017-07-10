using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUICanvas : Singleton<LevelUICanvas>
{  
    public GameObject EndLevelMenu;

    public Text TimerText;

    public Button MenuButton;

    public Button NextLevelButton;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        Scene current = SceneManager.GetActiveScene();
        if (PlayerManager.Instance.MaxLevel <= current.buildIndex)
        {
            this.NextLevelButton.interactable = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void PlayClip(AudioClip clip)
    {
        this.PlayClipFromPlayer(clip);
    }

    public void ToggleMenu()
    {
        this.EndLevelMenu.SetActive(!this.EndLevelMenu.activeSelf);
        if (this.EndLevelMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void NextLevel()
    {
        LevelManager.Instance.NextLevel();
    }

    public void ResetLevel()
    {
        LevelManager.Instance.ResetLevel();        
    }

    public void HomeClicked()
    {
        LevelManager.Instance.GoHome();
    }
}
