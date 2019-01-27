using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum End {Lost, Gone, Normal}

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

    static List<CharacterItem> mLeaveList;
    public List<CharacterItem> leaveList { get { return mLeaveList; } set { mLeaveList = value; } }

    public UnitSO[] stayArray;

    GameObject endingController;

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
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<Controller>().canControl = false;
            }

            //SceneManager.LoadScene(normalIndex);
            changed = true;

            if (GameObject.FindGameObjectWithTag("EndingController"))
            {
                GameObject.FindGameObjectWithTag("EndingController").GetComponent<EndingController>().EndWithParameter(End.Normal);
            }

            
        }
    }

    
}
