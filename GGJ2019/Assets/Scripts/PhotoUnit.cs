using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoUnit : MonoBehaviour
{
    public UnitSO unitSO;

    public float changeTime = 2;

    bool isLeaveList;
    bool leave;

    float time = 0;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();

        for (int i = 0; i < GlobalControl.Instance.stayArray.Length; i++)
        {
            if (GlobalControl.Instance.stayArray[i] == unitSO)
            {
                isLeaveList = false;
                break;
            }
        }

        if (isLeaveList)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
        }
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        }

        leave = false;
        if (unitSO.dead || unitSO.unitStatus == UnitStatus.Empty || unitSO.unitStatus == UnitStatus.Object)
        {
            leave = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeaveList)
        {
            if(!leave)
            {
                if(time < changeTime)
                {
                    time += Time.deltaTime;
                    sr.color = Color.Lerp(sr.color, new Color(sr.color.r, sr.color.g, sr.color.b, 1), 4 * Time.deltaTime);
                }
            }
        }
        else
        {

            if (leave)
            {
                if (time < changeTime)
                {
                    time -= Time.deltaTime;
                    sr.color = Color.Lerp(sr.color, new Color(sr.color.r, sr.color.g, sr.color.b, 0), 4 * Time.deltaTime);
                }
            }
        }
    }
}
