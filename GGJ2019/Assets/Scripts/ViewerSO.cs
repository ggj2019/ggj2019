using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/ViewerSO")]
public class ViewerSO : ScriptableObject
{
    public float xmin;
    public float xmax;
    public float velocity;
}