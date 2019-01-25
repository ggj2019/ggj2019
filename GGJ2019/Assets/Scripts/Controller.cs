using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float velocity = 1.0f;

    // SO for pack and maxium size is 2.
    public ListSO packSO;

    public GameObject pack;


    // Start is called before the first frame update
    void Start()
    {
        pack.GetComponent<PackManager>().packSO = packSO;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
             transform.position += new Vector3(0, 1, 0) * velocity;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, 1, 0) * velocity;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(1, 0, 0) * velocity;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * velocity;
        }
        
    }

    public void UpdatePack()
    {
        pack.GetComponent<PackManager>().UpdatePack();
    }
}
