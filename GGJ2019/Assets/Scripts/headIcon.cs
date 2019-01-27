using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headIcon : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(image.sprite == null)
        {
            image.color = new Color(255, 255, 255, 0);
        }
        else
        {
            image.color = new Color(255, 255, 255, 255);
        }
    }
}
