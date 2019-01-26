using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public NPCSO npcSO;
    public UnitSO unitSO;
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
        GlobalControl.Instance.npcPos = transform.position;

    }

    
}
