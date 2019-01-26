using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DescribeTextManager : MonoBehaviour
{
    static DescribeTextManager mInstance;
    public static DescribeTextManager Instance { get { return mInstance; } }

    public CanvasGroup rootCanvasGroup;
    public Text targetText;
    public LayerMask DescribeTextObjectLayerMask;


    void Awake()
    {
        mInstance = this;

        targetText.text = "";
    }

    void Update()
    {
        if (targetText.text.Length == 0)
        {
            rootCanvasGroup.alpha = 0f;
        }
        else
        {
            rootCanvasGroup.alpha = 1f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = default(RaycastHit);
            if (Physics.Raycast(ray, out hit, DescribeTextObjectLayerMask))
            {
                var content = hit.transform.GetComponent<DescribeTextObject>().content;

                PopupText(content);
            }
        }
    }

    public void PopupText(string content)
    {
        StopAllCoroutines();
        StartCoroutine(PopupTextCoroutine(content));
    }

    IEnumerator PopupTextCoroutine(string content)
    {
        var sb = new StringBuilder();
        yield return GradientText(content, str => targetText.text = str, sb, 0.8f);
        yield return new WaitForSeconds(2f);
        targetText.text = "";
    }

    IEnumerator GradientText(string textIn, Action<string> textOut, StringBuilder cacheSB, float duration)
    {
        Func<float, string> convertSourceText = (weight) =>
        {
            var textLength_f = (float)textIn.Length;

            for (int i = 0, iMax = textIn.Length; i < iMax; i++)
            {
                var singleChar = textIn[i];

                if (singleChar == '\n' || singleChar == '\r')
                {
                    cacheSB.Append(singleChar);
                    continue;
                }

                var relativeWeight = (i + 1) / textLength_f;
                var substract = weight - relativeWeight;

                if (substract >= 0)
                    cacheSB.Append(singleChar);
            }

            return cacheSB.ToString();
        };

        var beginTime = Time.unscaledTime;
        for (float d = duration; Time.unscaledTime - beginTime <= d;)
        {
            var t = (Time.unscaledTime - beginTime) / d;

            cacheSB.Length = 0;
            var r = convertSourceText(t);
            textOut(r);

            yield return null;
        }

        textOut(textIn);
    }
}
