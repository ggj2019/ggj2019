using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HeadIconUI : MonoBehaviour
{
    public UnitSO unitSO_test;
    public NPCSO npcSO;

    public GameObject currentNPC;
    public Image headPhotoImage;

    public ListSO totalSO;

    public int goneIndex;

    public TimerManager timerManager;

    public EndingController endingController;

    public Controller controller;

    public Gradient currentNPCToEdgeGradient = new Gradient()
    {
        colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(Color.white, 0f),
            new GradientColorKey(new Color(164f/255f,0f,0f), 1f)
        }
    };


    void OnEnable()
    {
        headPhotoImage.sprite = unitSO_test.peopleIcon;
    }

    void Update()
    {
        if (currentNPC && currentNPC.activeSelf)
        {
            const float EPS = 0.000001f;
            var t = Mathf.Clamp01(currentNPC.transform.position.magnitude / (npcSO.lengthLimit + EPS));
            var tt = Mathf.Max(0f, t - 0.6f) / 0.4f;

            headPhotoImage.color = currentNPCToEdgeGradient.Evaluate(tt);
            headPhotoImage.enabled = true;
        }
        else
        {
            
            bool gone = true;
            for(int i = 0; i < totalSO.units.Count; i++)
            {
                if(totalSO.units[i].unitStatus == UnitStatus.People || totalSO.units[i].unitStatus == UnitStatus.Union)
                {
                    gone = false;
                    break;
                }
            }
            if (gone)
            {
                controller.canControl = false;
                timerManager.canTime = false;
                endingController.EndWithParameter(End.Gone);
                //SceneManager.LoadScene(goneIndex);
            }
            headPhotoImage.enabled = false;
            GetComponent<HeadIconUI>().enabled = false;
        }
    }
}
