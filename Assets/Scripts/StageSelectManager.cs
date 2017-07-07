using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    public Text TitleText;

    public RectTransform Content;

    public string[] SceneNames;

    public LevelButton LevelButtonTemplate;

    // Use this for initialization
    void Start ()
    {
        float scaleFactor = (float)Screen.width / 800.0f;

        Time.timeScale = 1;

        int x = 64;
        int y = -64;

        int currLevel = 2;

        foreach (string sceneName in SceneNames)
        {            
            LevelButton button = Instantiate(LevelButtonTemplate);
            if (sceneName.StartsWith("_"))
            {
                continue;
            }

            button.transform.localScale *= scaleFactor;
            button.transform.SetParent(this.Content.transform, true);
            
            

            //button.transform.localPosition = new Vector3(x, y);

            // Note: first 2 stages are special
            button.SetText((currLevel - 1).ToString());
            button.SetNameText(sceneName);
            button.Level = currLevel;
            if (PlayerManager.Instance != null && currLevel > PlayerManager.Instance.MaxLevel)
            {
                button.Button.interactable = false;
            }

            currLevel++;
            
            //x += 128;
            //if (x > (128 * 3))
            //{
            //    x = 64;
            //    y -= 128;
            //}
        }      
    }

#if UNITY_EDITOR

    [UnityEditor.MenuItem("CONTEXT/StageSelectManager/Update Scene Names")]
    private static void UpdateNames(UnityEditor.MenuCommand command)
    {
        StageSelectManager obj = command.context as StageSelectManager;
        List<string> names = new List<string>();        
        foreach (UnityEditor.EditorBuildSettingsScene buildScene in UnityEditor.EditorBuildSettings.scenes)
        {
            string sceneName = Path.GetFileNameWithoutExtension(buildScene.path);
            names.Add(sceneName);
        }

        obj.SceneNames = names.ToArray();
        UnityEditor.EditorUtility.SetDirty(obj);
    }

#endif

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
