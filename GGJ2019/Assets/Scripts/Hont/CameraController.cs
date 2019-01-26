using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float tweenSpeed = 17f;
    public float distance = 5f;

    Transform mPlayerTransform;


    void OnEnable()
    {
        mPlayerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        var dstPoint = mPlayerTransform.position + Vector3.forward * distance;
        transform.position = Vector3.Lerp(transform.position, dstPoint, tweenSpeed * Time.smoothDeltaTime);
        transform.forward = -Vector3.forward;
    }
}
