using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    public ListSO packSO;

    public ListSO totalSO;

    public ListSO lostSO;

    bool isEmpty = false;

    public AudioSource simple;
    public AudioSource guitar;
    bool isGuitar = false;

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
            isGuitar = false;
            foreach (UnitSO u in totalSO.units)
            {
                if (u.objName == "Handsome")
                {
                    if (u.unitStatus == UnitStatus.Union)
                    {
                        isGuitar = true;

                    }
                    break;
                }
            }

            if (isGuitar)
            {
                guitar.Play();
            }
            else
            {
                simple.Play();
            }
        }
    }

    void UpdateUnit()
    {
        for(int i = 0; i < packSO.units.Count; i++)
        {
            int index = System.Array.IndexOf(UnitManager.Instance.LeaveHomeUnits, packSO.units[i]);
            if (index >= 0)
            {
                System.Array.Clear(UnitManager.Instance.LeaveHomeUnits, index, 1);
                UnitManager.Instance.isDirty = true;
            }
      
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
