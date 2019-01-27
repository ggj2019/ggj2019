using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeViewer : MonoBehaviour
{
    public ViewerSO viewerSO;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > viewerSO.xmin + viewerSO.velocity * Time.deltaTime)
            {
                transform.position -= viewerSO.velocity * Time.deltaTime * new Vector3(1, 0, 0);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < viewerSO.xmax - viewerSO.velocity * Time.deltaTime)
            {
                transform.position += viewerSO.velocity * Time.deltaTime * new Vector3(1, 0, 0);
            }
        }
    }
}
