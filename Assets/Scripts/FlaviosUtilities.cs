using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaviosUtilities
{
    
}

public static class FlaviosExtensionFunctions
{
    #region Move commands
    public static void MoveX(this MonoBehaviour obj, float amount)
    {
        obj.transform.position = new Vector3(obj.transform.position.x + amount, obj.transform.position.y);
    }

    public static void MoveY(this MonoBehaviour obj, float amount)
    {
        obj.transform.position = new Vector3(obj.transform.position.x + amount, obj.transform.position.y);
    }

    public static void SetYTo(this MonoBehaviour obj, float y)
    {
        Vector3 pos = obj.transform.position;
        obj.transform.position = new Vector3(pos.x, y, pos.z);
    }

    public static void SetXTo(this MonoBehaviour obj, float x)
    {
        Vector3 pos = obj.transform.position;
        obj.transform.position = new Vector3(x, pos.y, pos.z);
    }

    public static void MoveUp(this MonoBehaviour obj, float amount)
    {
        obj.MoveY(amount);
    }

    public static void MoveDown(this MonoBehaviour obj, float amount)
    {
        obj.MoveY(-amount);
    }

    public static void MoveLeft(this MonoBehaviour obj, float amount)
    {
        obj.MoveX(-amount);
    }

    public static void MoveRight(this MonoBehaviour obj, float amount)
    {
        obj.MoveX(amount);
    }

    public static void Goto(this MonoBehaviour obj, float x, float y)
    {
        obj.transform.position = new Vector3(x, y);
    }

    public static void FaceRight(this MonoBehaviour obj)
    {
        obj.transform.eulerAngles = new Vector3(0, 0, 0);        
    }

    public static void FaceLeft(this MonoBehaviour obj)
    {
        obj.transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public static void SpinAroundYAxis(this MonoBehaviour obj, float spinSpeed)
    {
        obj.transform.Rotate(Vector3.up, spinSpeed);
    }

    #endregion

    #region Rigidbody commands

    public static void ApplyForceUp(this MonoBehaviour obj, float force)
    {
        Rigidbody2D body = obj.GetComponent<Rigidbody2D>();
        if (body == null)
        {
            Debug.LogError("No Rigidbody attached!");
            return;
        }

        body.AddForce(Vector3.up * force, ForceMode2D.Impulse);
    }



    #endregion

    #region Position Info

    public static float GetPosX(this MonoBehaviour obj)
    {
        return obj.transform.position.x;
    }

    public static float GetPosY(this MonoBehaviour obj)
    {
        return obj.transform.position.y;
    }

    #endregion

    #region Component Helpers

    public static bool HasComponent<T>(this GameObject obj)
    {
        return obj.GetComponent<T>() != null;
    }

    public static bool HasComponentInChildren<T>(this GameObject obj)
    {
        return obj.GetComponentInChildren<T>(true) != null;
    }

    public static bool HasComponent<T>(this MonoBehaviour obj)
    {
        return obj.GetComponent<T>() != null;
    }

    public static bool HasComponentInChildren<T>(this MonoBehaviour obj)
    {
        return obj.GetComponentInChildren<T>(true) != null;
    }

    public static bool HasComponent<T>(this Collider2D obj)
    {
        return obj.GetComponent<T>() != null;
    }

    public static bool HasComponentInChildren<T>(this Collider2D obj)
    {
        return obj.GetComponentInChildren<T>(true) != null;
    }

    #endregion
}
