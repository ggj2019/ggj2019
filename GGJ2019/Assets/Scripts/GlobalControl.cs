using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;

    public int normalIndex;

    public float time;

    public Vector3 npcPos;
    public Vector3 npcDir;

    public Vector3 objPos;

    public bool timeIsSet = false;

    public bool spawnLeave = false;

    public List<CharacterItem> leaveList;

    public UnitSO[] stayArray;

    static bool changed;

    private void Awake()
    {
        changed = false;
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

    private void Update()
    {
        if(time < 0 && !changed)
        {
            SceneManager.LoadScene(normalIndex);
            changed = true;
        }
        
    }
}
