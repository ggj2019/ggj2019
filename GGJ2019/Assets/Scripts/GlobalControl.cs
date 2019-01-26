using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public float time;
    public Vector3 npcPos;
    public Vector3 npcDir;

    public Vector3 objPos;

    public bool timeIsSet = false;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != null)
        {
            Destroy(gameObject);
        }
    }
}
