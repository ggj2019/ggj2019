using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Hont;

public class Tumbleweed : MonoBehaviour
{
    public float scaleRandom = 0.15f;

    public float waitTimeMin = 1f;
    public float waitTimeMax = 2f;

    public float rollMoveSpeed = 0.5f;
    public float rollRotateSpeed = 700f;
    public float thumbleweedRollDurationTimeMin = 6f;
    public float thumbleweedRollDurationTimeMax = 8f;

    public float thumbleweedWaitTimeMin = 6f;
    public float thumbleweedWaitTimeMax = 8f;

    public int thumbleweedRollTimesMin = 2;
    public int thumbleweedRollTimesMax = 6;


    IEnumerator Start()
    {
        var originPosition = transform.position;
        var originRotation = transform.rotation;

        while (true)
        {
            transform.position = originPosition;
            transform.rotation = originRotation;
            transform.localScale = Vector3.zero;

            var beginTime = 0f;
            var rollDurationTime = Random.Range(thumbleweedRollDurationTimeMin, thumbleweedRollDurationTimeMax);
            var rollTimes = Random.Range(thumbleweedRollTimesMin, thumbleweedRollTimesMax);

            yield return new WaitForSeconds(Random.Range(waitTimeMin, waitTimeMax));

            beginTime = Time.time;
            var originScale = Vector3.one * 0.5f + Vector3.one * Random.Range(0, scaleRandom);
            for (var duration = 0.5f; Time.time - beginTime <= duration;)
            {
                var t = (Time.time - beginTime) / duration;

                transform.localScale = Vector3.Lerp(Vector3.zero, originScale, t);

                yield return null;
            }

            var atten = 3f;
            for (int i = 0; i < rollTimes; i++)
            {
                beginTime = Time.time;
                for (var duration = rollDurationTime; Time.time - beginTime <= duration;)
                {
                    transform.position += new Vector3(Mathf.Max(0f, rollMoveSpeed - atten), 0f, 0f) * Time.deltaTime;
                    transform.rotation = transform.rotation * Quaternion.AngleAxis(-rollRotateSpeed * Time.deltaTime, Vector3.forward);

                    atten = Mathf.Max(0f, atten - Time.deltaTime);

                    yield return null;
                }

                beginTime = Time.time;
                var waitTime = Random.Range(thumbleweedWaitTimeMin, thumbleweedWaitTimeMax);
                var atten2 = 3f;
                for (var duration = waitTime; Time.time - beginTime <= duration;)
                {
                    var rotationSpeed = -Mathf.Max((rollRotateSpeed - atten2), 0f) * Time.deltaTime;

                    transform.position += new Vector3(Mathf.Max(0f, rollMoveSpeed - atten2 * 0.003f), 0f, 0f) * Time.deltaTime;
                    transform.rotation = transform.rotation * Quaternion.AngleAxis(rotationSpeed, Vector3.forward);

                    atten2 = Mathf.Max(0f, atten2 + Time.deltaTime * 850f);

                    yield return null;
                }

                yield return new WaitForSeconds(waitTime * 0.6f);
            }

            beginTime = Time.time;
            originScale = transform.localScale;
            for (var duration = 0.5f; Time.time - beginTime <= duration;)
            {
                var t = (Time.time - beginTime) / duration;

                transform.localScale = Vector3.Lerp(originScale, Vector3.zero, t);

                yield return null;
            }

            yield return null;
        }
    }
}
