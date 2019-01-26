﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    public GameObject npc;
    public GameObject objTemplete;
    public NPCSO npcSO;
    public ListSO showSO;

    public GameObject playerArrow;

    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        npc.GetComponent<NPCBehavior>().npcSO = npcSO;

        if(showSO.units.Count == 1)
        {
            Debug.Log("here");
            npc.GetComponent<NPCBehavior>().unitSO = showSO.units[0];
            Instantiate(npc);

            objTemplete.GetComponent<ObjectBehavior>().unitSO = showSO.units[0];
            temp = Instantiate(objTemplete, GlobalControl.Instance.objPos, objTemplete.transform.rotation);
            playerArrow.GetComponent<PlayerArrow>().npcGO = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
