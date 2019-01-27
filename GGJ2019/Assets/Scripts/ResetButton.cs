using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ResetGlobal()
    {
        UnitManager.Instance.ManualGroup();
        GlobalControl.Instance.spawnLeave = false;
        GlobalControl.Instance.time = 0;
        GlobalControl.Instance.timeIsSet = false;
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
