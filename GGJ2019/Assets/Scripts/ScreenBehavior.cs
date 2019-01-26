using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehavior : MonoBehaviour
{
    public ListSO showSO;

    float timeSpentInvincible;

    public SpriteRenderer srScreen;

    SpriteRenderer sr;

    float time = 0;

    bool change = false;

    bool active = true;
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
            change = true;
        }

        if (change)
        {
            if (time < 1)
            {
                if(active)
                {
                    srScreen.color = Color.Lerp(srScreen.color, new Color(srScreen.color.r, srScreen.color.g, srScreen.color.b, 1), 0.1f);
                }
                
                else
                {
                    srScreen.color = Color.Lerp(srScreen.color, new Color(srScreen.color.r, srScreen.color.g, srScreen.color.b, 0), 0.1f);
                }
                time += Time.deltaTime;
            }
            else
            {
                time = 0;
                active = !active;
            }
        }
        
    }
}
