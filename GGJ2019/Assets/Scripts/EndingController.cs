using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    public Image backgroundBackTop;
    public Text centerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void EndWithParameter(End end)
    {
        StartCoroutine(EndGameCoroutine(end));
    }


    IEnumerator Show()
    {
        yield return new WaitForSeconds(0.3f);

        var beginTime = Time.time;
        for (var duration = 1f; Time.time - beginTime <= duration;)
        {
            var t = Time.time - beginTime / duration;
            var tt = (t - 1f) * (t - 1f) * (t - 1f) + 1f;

            backgroundBackTop.color = Color.Lerp(Color.black, new Color(0f, 0f, 0f, 0f), tt);

            yield return null;
        }
    }

    IEnumerator Fade()
    {
        var beginTime = Time.time;
        for (var duration = 1f; Time.time - beginTime <= duration;)
        {
            var t = Time.time - beginTime / duration;
            var tt = (t - 1f) * (t - 1f) * (t - 1f) + 1f;

            //elementRoot.alpha = Mathf.Lerp(1f, 0f, tt);j

            yield return null;
        }
        //elementRoot.alpha = 0f;
    }

    IEnumerator EndGameCoroutine(End end)
    {
        //yield return Fade();
        backgroundBackTop.enabled = true;

        yield return new WaitForSeconds(0.5f);

        string sentence1="";
        switch (end)
        {
            case End.Lost:
                sentence1 = "在追寻家人的途中，无线电信号丢失";
                break;
            case End.Gone:
                sentence1 = "虽然没能找回全部家人，但至少你找到了一半";
                break;
            case End.Normal:
                sentence1 = "恭喜你，成功留住了家人";
                break;
            default:
                break;
        }
        centerText.text = sentence1;

        var beginTime = Time.time;
        for (var duration = 1f; Time.time - beginTime <= duration;)
        {
            var t = Time.time - beginTime / duration;
            var tt = (t - 1f) * (t - 1f) * (t - 1f) + 1f;

            centerText.color = Color.Lerp(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 0.7f), tt);

            yield return null;
        }

        yield return new WaitForSeconds(0.7f);

        beginTime = Time.time;
        for (var duration = 1f; Time.time - beginTime <= duration;)
        {
            var t = Time.time - beginTime / duration;
            var tt = (t - 1f) * (t - 1f) * (t - 1f) + 1f;

            centerText.color = Color.Lerp(new Color(1f, 1f, 1f, 0.7f), new Color(1f, 1f, 1f, 0f), tt);

            yield return null;
        }

        yield return new WaitForSeconds(0.1f);

        string sentence2="";
        switch (end)
        {
            case End.Lost:
                sentence2 = "你将永远在星球上流浪";
                break;
            case End.Gone:
                sentence2 = "你的努力，换来今年的全家福";
                break;
            case End.Normal:
                sentence2 = "在0110201号星球，重建了家";
                break;
            default:
                break;
        }
        centerText.text = sentence2;

        beginTime = Time.time;
        for (var duration = 1f; Time.time - beginTime <= duration;)
        {
            var t = Time.time - beginTime / duration;
            var tt = (t - 1f) * (t - 1f) * (t - 1f) + 1f;

            centerText.color = Color.Lerp(new Color(1f, 1f, 1f, 0f), new Color(1f, 1f, 1f, 0.7f), tt);

            yield return null;
        }

        yield return new WaitForSeconds(0.7f);

        beginTime = Time.time;
        for (var duration = 1f; Time.time - beginTime <= duration;)
        {
            var t = Time.time - beginTime / duration;
            var tt = (t - 1f) * (t - 1f) * (t - 1f) + 1f;

            centerText.color = Color.Lerp(new Color(1f, 1f, 1f, 0.7f), new Color(1f, 1f, 1f, 0f), tt);

            yield return null;
        }

        switch (end)
        {
            case End.Lost:
                SceneManager.LoadScene(3);
                break;
            case End.Gone:
                SceneManager.LoadScene(4);
                break;
            case End.Normal:
                SceneManager.LoadScene(5);
                break;
            default:
                break;
        }
    }
}
