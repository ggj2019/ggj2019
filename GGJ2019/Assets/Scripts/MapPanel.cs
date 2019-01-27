using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPanel : MonoBehaviour
{
    public ListSO totalSO;
    public ListSO showSO;
    public bool isChanged;
    // Start is called before the first frame update
    void Start()
    {
        isChanged = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            UpdateIcon();
            isChanged = false;
        }
    }

    public void UpdateIcon()
    {
        for (int i = 0; i < 3; i++)
        {
            if(i < GlobalControl.Instance.leaveList.Count)
            {
                transform.GetChild(i).GetComponent<Image>().sprite =
                    GlobalControl.Instance.leaveList[i].unit.objectIcon;
                transform.GetChild(i).GetComponent<Image>().color = 
                    new Color(1, 1, 1, 1);
            }
            else
            {
                transform.GetChild(i).GetComponent<Image>().color =
                    new Color(0, 0, 0, 0);
            }
            
        }
        //if (showSO.units.Count != 0)
        //{
        //    transform.GetChild(3).GetComponent<Image>().sprite =
        //        showSO.units[0].objectIcon;
        //    transform.GetChild(3).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        //}
        //else
        //{
        //    transform.GetChild(3).GetComponent<Image>().color =
        //            new Color(0, 0, 0, 0);
        //}
       

    }
}
