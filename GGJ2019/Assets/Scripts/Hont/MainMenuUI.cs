using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Image backgroundBackTop;
    public Button startGameButton;
    public Button exitGameButton;
    public Animator animator;
    public Text centerText;
    public CanvasGroup elementRoot;


    void Awake()
    {
        startGameButton.onClick.AddListener(onStartGameBtnClicked);
        exitGameButton.onClick.AddListener(onExitGameBtnClicked);

        StartCoroutine(Show());
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

            elementRoot.alpha = Mathf.Lerp(1f, 0f, tt);

            yield return null;
        }
        elementRoot.alpha = 0f;
    }

    void onStartGameBtnClicked()
    {
        StartCoroutine(StartGameCoroutine());
    }

    void onExitGameBtnClicked()
    {
        Application.Quit();
    }

    IEnumerator StartGameCoroutine()
    {
        yield return Fade();
        animator.Play("Anim1");

        yield return new WaitForSeconds(0.5f);

        centerText.text = "千山鸟飞绝";

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

        centerText.text = "万径人踪灭";

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
    }
}
