using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitStatus {People, Object, Union, Empty};

public class UnitSystem : MonoBehaviour
{
    public UnitStatus unitStatus = UnitStatus.People;

    public UnitSO unitSO;

    void Start()
    {
    
    }

    void Update()
    {
        if(unitStatus != unitSO.unitStatus)
        {
            unitStatus = unitSO.unitStatus;
            Change(transform);
        }
        
    }

    void UpdateUnitSO(UnitSO unitSO)
    {
        if (unitSO)
        {
            unitSO.unitStatus = unitStatus;
        }
    }

    void Change(Transform trans)
    {
        SetChildFalse(trans);
        if(unitStatus != UnitStatus.Empty)
        {
            trans.GetChild((int)(unitStatus)).gameObject.SetActive(true);
        }
    }

    void SetChildFalse(Transform trans)
    {
        for (int i = 0; i < trans.childCount; i++)
        {
            trans.GetChild(i).gameObject.SetActive(false);
        }
    }
}
