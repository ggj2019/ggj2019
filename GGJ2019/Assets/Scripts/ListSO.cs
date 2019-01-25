using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ListSO")]
public class ListSO : ScriptableObject
{
    public List<UnitSO> units;
}