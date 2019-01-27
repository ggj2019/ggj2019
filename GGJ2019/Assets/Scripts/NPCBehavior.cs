using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public NPCSO npcSO;
    public UnitSO unitSO;

    void OnEnable()
    {
        GetComponent<SpriteRenderer>().sprite = unitSO.worldMapIcon;
    }

    private void Update()
    {
        if (Vector3.Distance(GlobalControl.Instance.npcPos, new Vector3(0, 0, 0)) >= npcSO.lengthLimit - 1)
        {
            //Debug.Log(npcSO.currentPos + " " + Vector3.Distance(npcSO.currentPos, new Vector3(0, 0, 0)) + " " + (npcSO.lengthLimit - 1));

            //Debug.Log("here wtf");
            unitSO.dead = true;
            Destroy(gameObject);
        }
        //Debug.Log("come");
        transform.position = GlobalControl.Instance.npcPos + (npcSO.lengthLimit / npcSO.timeLimit) * Time.deltaTime * GlobalControl.Instance.npcDir.normalized;
        transform.up = GlobalControl.Instance.npcDir;
        GlobalControl.Instance.npcPos = transform.position;

    }

    
}
