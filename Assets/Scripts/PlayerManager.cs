using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public int CurrentLevel = 1;
    public int MaxLevel = 0;

    public DictionaryOfIntAndInt Grades = new DictionaryOfIntAndInt();
    public DictionaryOfIntAndInt LevelScores = new DictionaryOfIntAndInt();

    public Sounds SoundClips;

    private AudioSource musicAndSounds;

    [Serializable]
    public class Sounds
    {
        public AudioClip Success;
    }       

    private int currClip = 0;
    public AudioClip[] Clips;

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

        this.musicAndSounds = this.GetComponent<AudioSource>();
    }    
	
    public void PlaySound(AudioClip clip, float volumeScale = 1.0f)
    {
        this.musicAndSounds.PlayOneShot(clip, volumeScale);
    }

	// Update is called once per frame
	void Update ()
    {	
        if (!this.musicAndSounds.isPlaying)
        {
            this.musicAndSounds.PlayOneShot(this.Clips[this.currClip]);
            this.currClip = this.currClip + 1 % this.Clips.Length;
        }
	}

    public void DeleteProgress()
    {
        // TODO
    }
}
