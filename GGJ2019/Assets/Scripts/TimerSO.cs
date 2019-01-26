﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TimerSO")]
public class TimerSO : ScriptableObject
{
    static bool isInit;
    public float timeLimit;
    public int round;

    public float current;

    float mCacheCurrent;

    private void OnEnable()
    {
        if (!isInit)
        {
            mCacheCurrent = current;
            isInit = true;
        }
        else
        {
            current = mCacheCurrent;
        }
    }

    void OnDisable()
    {
        if (Application.isPlaying)
            mCacheCurrent = current;
    }
}
