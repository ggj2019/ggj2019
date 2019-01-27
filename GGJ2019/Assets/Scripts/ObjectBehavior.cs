using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    public UnitSO unitSO;

    public ListSO lostSO;

    public ListSO showSO;

    [HideInInspector]
    public ListSO generatorSO;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (unitSO)
        {
            sr.sprite = unitSO.objectIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if(sr.enabled == false && unitSO)
        {
            sr.sprite = unitSO.objectIcon;
            sr.enabled = true;
        }

        if (unitSO.dead)
        {
            showSO.units.Remove(unitSO);
            lostSO.units.Remove(unitSO);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Controller controller = other.GetComponent<Controller>();
        if(controller.packSO.units.Count < 2)
        {
            controller.packSO.units.Add(unitSO);
            controller.UpdatePack();
            if (generatorSO && generatorSO.units.Contains(unitSO))
            {
                generatorSO.units.Remove(unitSO);
            }

            for (int i = 0; i < GlobalControl.Instance.leaveList.Count; i++)
            {
                if(GlobalControl.Instance.leaveList[i].unit == unitSO)
                {

                    GlobalControl.Instance.leaveList.RemoveAt(i);
                    Debug.Log(i +" "+GlobalControl.Instance.leaveList.Count);
                    break;
                }
            }

            showSO.units.Remove(unitSO);

            lostSO.units.Remove(unitSO);
            Destroy(gameObject);
        }
    }
}
