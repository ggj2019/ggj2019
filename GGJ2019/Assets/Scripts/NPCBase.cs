using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    public GameObject npc;
    public GameObject objTemplete;
    public NPCSO npcSO;
    public ListSO showSO;

    public GameObject playerArrow;

    public HeadIconUI headIconUI;

    GameObject temp;

    GameObject tempNPC;

    public GameObject leaveObjSpawner;

    GameObject tempSpawner;

    //public GameObject objTemplete;

    // Start is called before the first frame update
    void Start()
    {
        if (!GlobalControl.Instance.spawnLeave)
        {
            leaveObjSpawner.GetComponent<CharacterItemsSpawner>().soList = UnitManager.Instance.LeaveHomeUnits;
        }

        npc.GetComponent<NPCBehavior>().npcSO = npcSO;

        if(showSO.units.Count == 1)
        {
            npc.GetComponent<NPCBehavior>().unitSO = showSO.units[0];
            tempNPC = Instantiate(npc);

            objTemplete.GetComponent<ObjectBehavior>().unitSO = showSO.units[0];
            temp = Instantiate(objTemplete, GlobalControl.Instance.objPos, objTemplete.transform.rotation);
            playerArrow.GetComponent<PlayerArrow>().npcGO = temp;

            headIconUI.unitSO_test = showSO.units[0];
            headIconUI.currentNPC = tempNPC;
            headIconUI.enabled = true;
        }
        if (!GlobalControl.Instance.spawnLeave)
        {
            tempSpawner = Instantiate(leaveObjSpawner);
            GlobalControl.Instance.leaveList = new List<CharacterItem>(tempSpawner.GetComponent<CharacterItemsSpawner>().InstancedCharacterItemList);
            GlobalControl.Instance.spawnLeave = true;
        }


        for(int i = 0; i < GlobalControl.Instance.leaveList.Count; i++)
        {
            objTemplete.GetComponent<ObjectBehavior>().unitSO = GlobalControl.Instance.leaveList[i].unit;
            Instantiate(objTemplete, GlobalControl.Instance.leaveList[i].position, objTemplete.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
