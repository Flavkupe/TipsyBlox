using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager> {

    public int ThisLevel;

    public List<Block> Blocks;

    public string NextSceneName;

    public List<Zone> Zones;

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

        if (PlayerManager.Instance == null)
        {
            Instantiate(PlayerManagerTemplate);
        }

        this.Blocks = GameObject.FindGameObjectsWithTag("Block").Select(a => a.GetComponent<Block>()).Where(b => b != null).ToList();
        this.Zones = GameObject.FindGameObjectsWithTag("Zone").Select(a => a.GetComponent<Zone>()).Where(b => b != null).ToList();

        foreach (Zone zone in this.Zones)
        {
            zone.InitZone();
        }
    }
	
	// Update is called once per frame
	void Update () {
		if (this.Blocks.Count == 0)
        {
            SceneManager.LoadScene(NextSceneName);
        }
	}
}