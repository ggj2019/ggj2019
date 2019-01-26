using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/NPCSO")]
public class NPCSO : ScriptableObject
{
    static bool isInit;

    public float lengthLimit;

    public float effectLength;

    public float timeLimit;

    public Vector3 currentPos;

    public Vector3 dir;


    Vector3 mCacheCurrentPos;

    Vector3 mCacheDir;

    private void OnEnable()
    {
        if (!isInit)
        {
            isInit = true;
        }
        else
        {
            currentPos = mCacheCurrentPos;
            dir = mCacheDir;
        }
    }

    void OnDisable()
    {
        if (Application.isPlaying)
        {
            mCacheCurrentPos = currentPos;
            mCacheDir = dir;
        }
            
    }
}

