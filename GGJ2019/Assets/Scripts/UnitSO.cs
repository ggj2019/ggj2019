using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/UnitSO")]
public class UnitSO : ScriptableObject
{
    public UnitStatus unitStatus;
    public Sprite peopleIcon;
    public Sprite objectIcon;
    public string objName;
    public bool dead;
}
