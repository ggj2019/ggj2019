using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public ListSO totalSO;
    public AudioSource simple;
    public AudioSource guitar;
    bool isGuitar = false;
    // Start is called before the first frame update
    void Start()
    {
        isGuitar = false;
        foreach(UnitSO u in totalSO.units)
        {
            if(u.objName == "Handsome")
            {
                if(u.unitStatus == UnitStatus.Union)
                {
                    isGuitar = true;
                    
                }
                break;
            }
        }

        if (isGuitar)
        {
            guitar.Play();
        }
        else
        {
            simple.Play();
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
