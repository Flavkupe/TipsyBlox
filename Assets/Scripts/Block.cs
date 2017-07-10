using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public BlockShape Shape;

    public BlockColor Color;

    private Rigidbody2D body;

    public AudioClip TocSound;
    public AudioClip HitGoalSound;

    // Use this for initialization
    void Start () {
        this.body = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Match()
    {
        LevelManager.Instance.MatchBlock(this);
        StartCoroutine(this.Shrink());
        if (HitGoalSound != null)
        {
            PlayerManager.Instance.PlaySound(HitGoalSound);
        }

        Destroy(this.gameObject, 0.3f);
    }

    private IEnumerator Shrink()
    {
        while (this.gameObject != null && this.transform.localScale.x > 0.0)
        {
            if (this.gameObject != null)
            {
                this.transform.localScale *= 0.98f;                    
            }

            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (TocSound != null && this.body.velocity.magnitude > 3.0f)
        {
            float vol = Mathf.Min(1.0f, 6.0f / this.body.velocity.magnitude);
            PlayerManager.Instance.PlaySound(TocSound, vol);
        }
    }
}

public enum BlockShape
{
    Triangle,
    Box,
    Circle
}

public enum BlockColor
{
    Red,
    Blue,
    Green,
    Yellow,
    None
}