using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text TitleText;
    
    void Start () {
        Time.timeScale = 1;
        SerializationManager.Instance.Load();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartClicked()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelsClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    private bool goingUp = false;
    private void FixedUpdate()
    {
        if (goingUp && TitleText.fontSize > 60)
        {
            goingUp = false;
        }
        else if (!goingUp && TitleText.fontSize < 42)
        {
            goingUp = true;
        }

        TitleText.fontSize += goingUp ? 1 : -1;
    }
}
