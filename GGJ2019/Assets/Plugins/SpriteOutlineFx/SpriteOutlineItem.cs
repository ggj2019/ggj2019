using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOutlineItem : MonoBehaviour
{
    void Awake()
    {
        if (GameObject.FindObjectOfType<SpriteOutlineFx>() == null)
            Camera.main.gameObject.AddComponent<SpriteOutlineFx>();

        enabled = false;
    }

    void OnEnable()
    {
        SpriteOutlineFx.outlineItemList.Add(this);
    }

    void OnDisable()
    {
        SpriteOutlineFx.outlineItemList.Remove(this);
    }
}
