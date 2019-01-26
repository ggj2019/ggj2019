using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehavior : MonoBehaviour
{
    public ListSO showSO;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!sr.enabled && showSO.units.Count == 1)
        {
            sr.sprite = showSO.units[0].objectIcon;
            sr.enabled = true;
        }
    }
}
