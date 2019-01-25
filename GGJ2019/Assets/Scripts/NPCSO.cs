using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/NPCSO")]
public class NPCSO : ScriptableObject
{
    public float lengthLimit;
    public float timeLimit;

    public Vector3 currentPos;

    public Vector3 dir;
}

