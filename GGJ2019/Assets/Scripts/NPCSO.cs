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
}

