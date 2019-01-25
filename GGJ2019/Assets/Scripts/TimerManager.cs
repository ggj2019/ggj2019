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

    public UnitSO specialSO;

    GameObject npcNew;
    GameObject objNew;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int count = (int)(timerSO.current / timerSO.round);
        timeText.text = count.ToString();
        timeImage.fillAmount = (timerSO.current / timerSO.round) - count;
        float oldTime = timerSO.current;
        if(timerSO.current - Time.deltaTime < 0)
        {
            timerSO.current = 0;
        }
        else
        {
            timerSO.current -= Time.deltaTime;
            if (Mathf.CeilToInt(oldTime) != Mathf.CeilToInt(timerSO.current) && Mathf.CeilToInt(timerSO.current) % timerSO.round == 0)
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

            // random and create npc movement;
            NPCBehavior npcBe = npc.GetComponent<NPCBehavior>();
            //npcBe.unitSO = specialSO;
            RandomNewNPC(npcBe.npcSO);
            npcNew = Instantiate(npc);

            // create obj 
            obj.GetComponent<ObjectBehavior>().unitSO = specialSO;
            CreateObj(obj);
            //Instantiate(obj);
        }

    }

    void RandomNewNPC(NPCSO npcSO)
    {
        npcSO.currentPos = new Vector3(0, 0, 0);
        npcSO.dir = Random.insideUnitCircle;
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
        objNew = Instantiate(obj, obj.transform.position - new Vector3(1, 1, 0),obj.transform.rotation);
    }
}
