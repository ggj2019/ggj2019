using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoSceneManager : MonoBehaviour
{

    public ListSO totalSO;

    bool isLeaveList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < totalSO.units.Count; i++)
        {
            isLeaveList = true;
            for (int j = 0; j < GlobalControl.Instance.stayArray.Length; j ++)
            {
                if(GlobalControl.Instance.stayArray[j] == totalSO.units[i])
                {
                    isLeaveList = false;
                }
            }

            // leavelist    stay
            

            // leavelist    leave
            
            // staylist     stay
            
            // staylist     leave
        }
    }

    public void UpdatePhoto(UnitSO unitSO)
    {

    }
}
