using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class TimerManager : MonoBehaviour
{
    public Image timeImage;
    public Text timeText;

    public TimerSO timerSO;

    public ListSO lostSO;

    public GameObject npc;
    public GameObject obj;

    public ListSO showSO;

    [HideInInspector]
    public UnitSO specialSO;

    GameObject npcNew;
    GameObject objNew;

    public GameObject objSpawner;

    public GameObject objTemplete;

    public HeadIconUI headIconUI;

    GameObject tempSpawner;
    // Start is called before the first frame update
    void Start()
    {
        if (!GlobalControl.Instance.timeIsSet){
            GlobalControl.Instance.time = timerSO.timeLimit;
            GlobalControl.Instance.timeIsSet = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Resources.Load();
        int count = (int)(GlobalControl.Instance.time / timerSO.round);
        timeText.text = count.ToString();
        timeImage.fillAmount = (GlobalControl.Instance.time / timerSO.round) - count;
        float oldTime = GlobalControl.Instance.time;
        if(GlobalControl.Instance.time - Time.deltaTime < 0)
        {
            GlobalControl.Instance.time = 0;
        }
        else
        {
            GlobalControl.Instance.time -= Time.deltaTime;
            if (Mathf.CeilToInt(oldTime) != Mathf.CeilToInt(GlobalControl.Instance.time) && Mathf.CeilToInt(GlobalControl.Instance.time) % timerSO.round == 0)
            {
                //Debug.Log("here");
                Tick();
            }
        }
    }

    void Tick()
    {
        if (npcNew && specialSO)
        {
            specialSO.dead = true;
            Destroy(npcNew);
        }
        if (objNew)
        {
            Destroy(objNew);
        }
        if(specialSO && specialSO.dead &&specialSO.unitStatus == UnitStatus.People)
        {
            specialSO.unitStatus = UnitStatus.Empty;
        }
        lostSO.units.Remove(specialSO);

        // get random special
        //CopyUnitSO(RandomUnit(lostSO), specialSO);
        if(lostSO.units.Count != 0)
        {
            specialSO = RandomUnit(lostSO);
            showSO.units.Clear();
            showSO.units.Add(specialSO);
            specialSO.unitStatus = UnitStatus.Empty;

            // random and create npc movement;
            NPCBehavior npcBe = npc.GetComponent<NPCBehavior>();
            npcBe.unitSO = specialSO;
            RandomNewNPC(npcBe.npcSO);
            npcNew = Instantiate(npc);

            headIconUI.unitSO_test = specialSO;
            headIconUI.currentNPC = npcNew;

            headIconUI.enabled = true;

            // create obj 
            obj.GetComponent<ObjectBehavior>().unitSO = specialSO;

            objSpawner.GetComponent<CharacterItemsSpawner>().npcSO = npcBe.npcSO;
            objSpawner.GetComponent<CharacterItemsSpawner>().soList = new UnitSO[] { specialSO };

            tempSpawner = Instantiate(objSpawner);
            GlobalControl.Instance.objPos = tempSpawner.GetComponent<CharacterItemsSpawner>().InstancedCharacterItemList[0].position;

            objTemplete.GetComponent<ObjectBehavior>().unitSO = specialSO;

            GameObject tempObj = Instantiate(objTemplete, GlobalControl.Instance.objPos, objTemplete.transform.rotation);


            
            //Destroy(tempSpawner);
            
            //objBe.generatorSO = generatorSO;

        }

    }

    void RandomNewNPC(NPCSO npcSO)
    {
        Debug.Log("Random a npc");
        GlobalControl.Instance.npcPos = new Vector3(0, 0, 0);
        GlobalControl.Instance.npcDir = Random.insideUnitCircle;
        npcSO.timeLimit = timerSO.round;
    }

    UnitSO RandomUnit(ListSO so)
    {
        int p = Random.Range(0, so.units.Count);
        return so.units[p];
    }

    void CopyUnitSO(UnitSO source, UnitSO dest)
    {
        dest.unitStatus = source.unitStatus;
        dest.objectIcon = source.objectIcon;
        dest.peopleIcon = source.peopleIcon;
    }

    void CreateObj(GameObject obj)
    {
        //objNew = Instantiate(obj, obj.transform.position - new Vector3(1, 1, 0),obj.transform.rotation);
    }
}
