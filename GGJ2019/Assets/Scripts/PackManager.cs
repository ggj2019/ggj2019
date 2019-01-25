using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PackManager : MonoBehaviour
{
    [HideInInspector]
    public ListSO packSO;

    Image item0;
    Image item1;

    // Start is called before the first frame update
    void Start()
    {
        item0 = transform.GetChild(0).GetComponent<Image>();
        item1 = transform.GetChild(1).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePack()
    {
        int count = packSO.units.Count;
        if (count == 0)
        {
            item0.enabled = false;
            item1.enabled = false;
        }
        else if(count == 1)
        {
            item0.sprite = packSO.units[0].objectIcon;
            item0.enabled = true;
            item1.enabled = false;
        }
        else if(count == 2)
        {
            item0.sprite = packSO.units[0].objectIcon;
            item1.sprite = packSO.units[1].objectIcon;
            item0.enabled = true;
            item1.enabled = true;
        }
        else
        {
            Debug.Log("holy shit");
        }
    }
}
