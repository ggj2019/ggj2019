using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    public float velocity = 1.0f;

    // SO for pack and maxium size is 2.
    public ListSO packSO;

    public GameObject pack;

    public NPCSO npcSO;

    public Image backgroundImg;

    public int lostEndIndex;

    public bool canControl;

    public EndingController endingController;

    public TimerManager timerManager;

    // Start is called before the first frame update
    void Start()
    {
        canControl = true;
        pack.GetComponent<PackManager>().packSO = packSO;
    }

    // Update is called once per frame
    void Update()
    {
        if (canControl)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, 1, 0) * velocity;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, 1, 0) * velocity;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(1, 0, 0) * velocity;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0) * velocity;
            }

            UpdateMask(backgroundImg);
        }
        
    }

    public void UpdatePack()
    {
        pack.GetComponent<PackManager>().UpdatePack();
    }

    void UpdateMask(Image img)
    {
        float length = Vector3.Distance(transform.position, new Vector3(0, 0, 0));
        

        if (length >= npcSO.lengthLimit)
        {
            canControl = false;

            timerManager.canTime = false;

            endingController.EndWithParameter(End.Lost);
            
            //SceneManager.LoadScene(lostEndIndex);
        }

        Color color = img.color;
        if (length + npcSO.effectLength >= npcSO.lengthLimit)
        {
            float alpha = 1 - ((npcSO.lengthLimit - length) / npcSO.effectLength);

            img.color = new Color(color.r, color.g, color.b, alpha);
        }
        else
        {
            img.color = new Color(color.r, color.g, color.b, 0);
        }

       
        
    }
}
