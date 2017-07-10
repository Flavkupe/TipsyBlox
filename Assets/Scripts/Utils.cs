using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;


[Serializable]
public class DictionaryOfIntAndInt : Dictionary<int, int>
{
    public DictionaryOfIntAndInt() { }
    protected DictionaryOfIntAndInt(SerializationInfo info, StreamingContext ctx) : base(info, ctx) {}
}

public static class Utils
{
    public static Vector3 ClampAngle(Vector3 eulerAngles, float min, float max)
    {
        return new Vector3(Utils.ClampAngle(eulerAngles.x, min, max), Utils.ClampAngle(eulerAngles.y, min, max), 0);
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle > 180)
        {
            angle = angle - 360;
        }

        angle = Mathf.Clamp(angle, min, max);
        if (angle < 0)
        {
            angle = 360 + angle;
        }

        return angle;
    }

    public static void PlayClipFromPlayer(this MonoBehaviour me, AudioClip clip)
    {
        if (PlayerManager.Instance != null)
        {
            PlayerManager.Instance.PlaySound(clip);
        }
    }
}
