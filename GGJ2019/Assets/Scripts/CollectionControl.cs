using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnitManager.Instance.isDirty = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(UnitManager.Instance.isDirty);
        if (UnitManager.Instance.isDirty)
        {
            for(int j = 0; j < transform.childCount; j++)
            {
                transform.GetChild(j).GetComponent<Image>().enabled = false;
            }
            for (int i = 0; i < UnitManager.Instance.LeaveHomeUnits.Length; i++)
            {
                if (UnitManager.Instance.LeaveHomeUnits[i])
                {
                    transform.GetChild(i).GetComponent<Image>().sprite = UnitManager.Instance.LeaveHomeUnits[i].objectIcon;
                    transform.GetChild(i).GetComponent<Image>().enabled = true;
                }
            }
            UnitManager.Instance.isDirty = false;
        }
    }
}
