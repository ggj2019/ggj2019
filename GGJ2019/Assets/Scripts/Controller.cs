using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{

    public float velocity = 1.0f;

    // SO for pack and maxium size is 2.
    public ListSO packSO;

    public GameObject pack;

    public NPCSO npcSO;

    public Image backgroundImg;

    // Start is called before the first frame update
    void Start()
    {
        pack.GetComponent<PackManager>().packSO = packSO;
    }

    // Update is called once per frame
    void Update()
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

    public void UpdatePack()
    {
        pack.GetComponent<PackManager>().UpdatePack();
    }

    void UpdateMask(Image img)
    {
        float length = Vector3.Distance(transform.position, new Vector3(0, 0, 0));
        Color color = img.color;
        if (length + npcSO.effectLength >= npcSO.lengthLimit)
        {
            float alpha = 1 - ((npcSO.lengthLimit - length) / npcSO.effectLength);

            //Debug.Log(alpha + " " + length + " " + (int)((npcSO.lengthLimit - length) / npcSO.effectLength * 255));

            img.color = new Color(color.r, color.g, color.b, alpha);
        }
        else
        {
            img.color = new Color(color.r, color.g, color.b, 0);
        }
        
    }
}
