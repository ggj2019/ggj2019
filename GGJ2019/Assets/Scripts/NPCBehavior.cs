using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    public NPCSO npcSO;
    public UnitSO unitSO;
    private void Update()
    {
        if (Vector3.Distance(transform.position, new Vector3(0, 0, 0)) >= npcSO.lengthLimit - 1)
        {
            
            unitSO.dead = true;
            Destroy(gameObject);
        }
        transform.position = npcSO.currentPos + (npcSO.lengthLimit / npcSO.timeLimit) * Time.deltaTime * npcSO.dir.normalized;
        npcSO.currentPos = transform.position;

    }

    
}
