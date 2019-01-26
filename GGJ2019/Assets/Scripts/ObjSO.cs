using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ObjSO")]
public class ObjSO : ScriptableObject
{
    static bool isInit;

    public Vector3 pos;

    public Vector3 dir;


    Vector3 mCacheCurrentPos;

    private void OnEnable()
    {
        if (!isInit)
        {
            mCacheCurrentPos = pos;
            isInit = true;
        }
        else
        {
            pos = mCacheCurrentPos;
        }
    }

    void OnDisable()
    {
        if (Application.isPlaying)
            mCacheCurrentPos = pos;
    }
}