using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int Level;

    public TextMeshProUGUI Text;

    public TextMeshProUGUI NameText;

    public void ButtonClicked()
    {
        SceneManager.LoadScene(Level);
    }

	// Use this for initialization
	void Start ()
    {
	}
	
    public void SetText(string text)
    {
        this.Text.text = text;
    }

    public void SetNameText(string text)
    {
        this.NameText.text = text;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
