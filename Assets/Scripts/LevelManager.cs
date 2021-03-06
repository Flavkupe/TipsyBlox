﻿using System.Collections;
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

public class LevelManager : Singleton<LevelManager>
{
    public int ThisLevel;

    public bool LastLevel = false;

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
    void Start ()
    {
        instance = this;

        Time.timeScale = 1;

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

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    private bool beatLevel = false;
    
	void Update ()
    {
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
        this.PlayClipFromPlayer(PlayerManager.Instance.SoundClips.Success);
        int sceneNum = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerManager.Instance.MaxLevel = Mathf.Max(sceneNum, PlayerManager.Instance.MaxLevel);        
        int grade = 0;
        if (this.timer <= this.Reqs.AReq)
        {
            // The "A" face
            grade = 3;
            cube.transform.eulerAngles = new Vector3(0, -90.0f, 0);
        }
        else if (this.timer <= this.Reqs.BReq)
        {
            grade = 2;
            // The "B" face
            cube.transform.eulerAngles = new Vector3(0, 180.0f, 0);
        }
        else
        {
            grade = 1;
            // The "C" face
            cube.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        int maxGrade = PlayerManager.Instance.Grades.ContainsKey(sceneNum) ? PlayerManager.Instance.Grades[sceneNum] : 0;
        PlayerManager.Instance.Grades[sceneNum] = Math.Max(maxGrade, grade);        
        cube.SetActive(true);
        cube.transform.position = new Vector3(-11, 0, -1);

        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(SlideTo(cube, new Vector3(0, 0, -1), 2.0f));
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(SlideTo(cube, new Vector3(-1.0f, 0, -1), 5.0f));
        yield return StartCoroutine(SlideTo(cube, new Vector3(11.0f, 0, -1), 5.0f));

        SerializationManager.Instance.Save();

        this.ShowEndMenu();

        yield return null;   
    }

    public void ShowEndMenu()
    {
        if (LevelUICanvas.Instance.EndLevelMenu != null)
        {
            LevelUICanvas.Instance.EndLevelMenu.SetActive(true);
            LevelUICanvas.Instance.NextLevelButton.interactable = true;
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
        Time.timeScale = 1;
        int sceneNum = this.LastLevel ? 0 : SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(sceneNum);                
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);        
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