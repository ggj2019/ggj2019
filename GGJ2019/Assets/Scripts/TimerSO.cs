using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/TimerSO")]
public class TimerSO : ScriptableObject
{
    public float timeLimit;
    public int round;

    public float current;
}
