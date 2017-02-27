using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

[Serializable]
public class LevelReqs
{
    public float AReq;
    public float BReq;    
}

public class LevelManager : Singleton<LevelManager> {

    public int ThisLevel;    

    public List<Block> Blocks;

    public List<Zone> Zones;

    public LevelReqs Reqs = new LevelReqs();    

    private float timer = 0.0f;

    private GameObject cube;

    public void MatchBlock(Block block)
    {
        this.Blocks.Remove(block);
    }

    public void DestroyZone(Zone zone)
    {
        this.Zones.Remove(zone);
    }

    public PlayerManager PlayerManagerTemplate;

    // Use this for initialization
    void Start () {
        instance = this;        

        this.cube = Instantiate(Resources.Load("GradeCube")) as GameObject;
        this.cube.SetActive(false);

        if (PlayerManager.Instance == null)
        {
            Instantiate(PlayerManagerTemplate);
        }

        this.Blocks = GameObject.FindObjectsOfType<Block>().Select(a => a.GetComponent<Block>()).Where(b => b != null).ToList();
        this.Zones = GameObject.FindObjectsOfType<Zone>().Select(a => a.GetComponent<Zone>()).Where(b => b != null).ToList();

        foreach (Zone zone in this.Zones)
        {
            zone.InitZone();
        }
    }

    private bool beatLevel = false;

	// Update is called once per frame
	void Update () {

        if (beatLevel)
        {
            return;
        }

        this.timer += Time.deltaTime;

        LevelUICanvas.Instance.TimerText.text = this.timer.ToString("N2");

        if (this.Blocks.Count == 0)
        {
            beatLevel = true;            
            StartCoroutine(BeatLevel());
        }
	}

    private IEnumerator BeatLevel()
    {        
        if (this.timer <= this.Reqs.AReq)
        {
            // The "A" face
            cube.transform.eulerAngles = new Vector3(0, -90.0f, 0);
        }
        else if (this.timer <= this.Reqs.BReq)
        {
            // The "B" face
            cube.transform.eulerAngles = new Vector3(0, 180.0f, 0);
        }
        else
        {
            // The "C" face
            cube.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        cube.SetActive(true);
        cube.transform.position = new Vector3(-11, 0, -1);

        yield return StartCoroutine(SlideTo(cube, new Vector3(0, 0, -1), 2.0f));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(SlideTo(cube, new Vector3(-1.0f, 0, -1), 5.0f));
        yield return StartCoroutine(SlideTo(cube, new Vector3(11.0f, 0, -1), 5.0f));

        this.ShowEndMenu();
    }

    public void ShowEndMenu()
    {
        if (LevelUICanvas.Instance.EndLevelMenu != null)
        {
            LevelUICanvas.Instance.EndLevelMenu.SetActive(true);
        }
        else
        {
            this.NextLevel();
        }        
    }

    public void PlayerDied()
    {
        this.ResetLevel();
    }

    public void NextLevel()
    {
        string next = "Level" + (this.ThisLevel + 1);
        SceneManager.LoadScene(next);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator SlideTo(GameObject obj, Vector3 target, float speed)
    {
        while (Vector3.Distance(obj.transform.position, target) > 0.1f)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, target, 0.03f * speed);
            yield return null;
        }
    }
}