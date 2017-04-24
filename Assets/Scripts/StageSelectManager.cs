using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    public Text TitleText;

    public RectTransform Content;

    public LevelButton LevelButtonTemplate;

    // Use this for initialization
    void Start ()
    {
        Time.timeScale = 1;

        int x = 64;
        int y = -64;

        int currLevel = 2;

        foreach (EditorBuildSettingsScene buildScene in EditorBuildSettings.scenes)
        {            
            LevelButton button = Instantiate(LevelButtonTemplate);            
            string sceneName = Path.GetFileNameWithoutExtension(buildScene.path);
            if (sceneName.StartsWith("_"))
            {
                continue;
            }

            button.transform.SetParent(this.Content.transform);
            button.transform.localPosition = new Vector3(x, y);
            
            // Note: first 2 stages are special
            button.SetText((currLevel - 1).ToString());
            button.SetNameText(sceneName);
            button.Level = currLevel;
            currLevel++;
            x += 96;
            if (x > (96 * 3))
            {
                x = 64;
                y -= 128;
            }
        }

        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private bool goingUp = false;

    private void FixedUpdate()
    {
        if (goingUp && TitleText.fontSize > 45)
        {
            goingUp = false;
        }
        else if (!goingUp && TitleText.fontSize < 30)
        {
            goingUp = true;
        }

        TitleText.fontSize += goingUp ? 1 : -1;
    }
}
