using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public ListSO packSO;

    public ListSO totalSO;

    public ListSO lostSO;

    bool isEmpty = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < totalSO.units.Count; i++)
        {
            if(totalSO.units[i].unitStatus == UnitStatus.People && !lostSO.units.Contains(totalSO.units[i]) && !packSO.units.Contains(totalSO.units[i]))
            {
                lostSO.units.Add(totalSO.units[i]);              
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(packSO.units.Count);
        if(isEmpty == false)
        {
            UpdateUnit();
        }
    }

    void UpdateUnit()
    {
        for(int i = 0; i < packSO.units.Count; i++)
        {
            if (!packSO.units[i].dead)
            {
                packSO.units[i].unitStatus = UnitStatus.Union;
            }
            else
            {
                packSO.units[i].unitStatus = UnitStatus.Object;
            }
            
        }
        packSO.units.Clear();
        isEmpty = true;
    }
}
