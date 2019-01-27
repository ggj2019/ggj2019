using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.Rendering;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/2D Sprite/Outline")]
public class SpriteOutlineFx : MonoBehaviour
{
    [SerializeField] Color _outlineColor = new Color(128f / 255f, 0f, 0f, 1f);

    public Color outlineColor
    {
        get { return _outlineColor; }
        set { _outlineColor = value; }
    }

    [SerializeField] float _sampleDistance = 2;

    public float sampleDistance
    {
        get { return _sampleDistance; }
        set { _sampleDistance = value; }
    }

    Material _material;
    CommandBuffer mCB;

    public static List<SpriteOutlineItem> outlineItemList = new List<SpriteOutlineItem>();


    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var hit = default(RaycastHit);
        if (Physics.Raycast(ray, out hit, 1 << 8))
        {
            hit.transform.GetComponent<SpriteOutlineItem>().enabled = true;
        }
        else
        {
            for (int i = outlineItemList.Count - 1; i >= 0; i--)
            {
                outlineItemList[i].enabled = false;
            }
            outlineItemList.Clear();
        }
    }

    void Setup()
    {
        if (_material == null)
        {
            _material = new Material(Shader.Find("Hidden/Sprite Outline"));
            _material.hideFlags = HideFlags.DontSave;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Setup();

        _material.SetFloat("_Distance", _sampleDistance);
        _material.SetColor("_Color", _outlineColor);

        if (mCB == null)
            mCB = new CommandBuffer();

        mCB.Clear();
        foreach (var item in outlineItemList)
        {
            var renderer = item.GetComponentInParent<Renderer>();
            if (renderer)
                mCB.DrawRenderer(renderer, _material);
        }

        Graphics.Blit(source, destination);
        Graphics.ExecuteCommandBuffer(mCB);
    }
}
