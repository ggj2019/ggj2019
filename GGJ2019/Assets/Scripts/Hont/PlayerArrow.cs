using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    public float distance = 0.9f;
    public GameObject npcGO;
    SpriteRenderer mSpriteRenderer;
    Transform mPlayerTransform;


    void OnEnable()
    {
        mPlayerTransform = GameObject.FindWithTag("Player").transform;
        mSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (mPlayerTransform == null) return;

        if (npcGO)
        {
            var dir = (npcGO.transform.position - mPlayerTransform.position).normalized;

            transform.position = mPlayerTransform.position + dir * distance;
            transform.up = dir;

            mSpriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0.2f, 0.7f, Mathf.PingPong(Time.time, 1f)));
            mSpriteRenderer.enabled = true;
        }
        else
        {
            mSpriteRenderer.enabled = false;
        }
    }
}
