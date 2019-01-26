﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    public GameObject npc;
    public NPCSO npcSO;
    public ListSO showSO;

    // Start is called before the first frame update
    void Start()
    {
        npc.GetComponent<NPCBehavior>().npcSO = npcSO;

        if(showSO.units.Count == 1)
        {
            npc.GetComponent<NPCBehavior>().unitSO = showSO.units[0];
        }
        
        Instantiate(npc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
