using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    public float minSpeed = 5;

    public float maxSpeed = 15;

    public bool speedUp;

    float oldSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            oldSpeed = collision.GetComponent<Controller>().velocity;
            if (speedUp)
            {
                collision.GetComponent<Controller>().velocity = maxSpeed;
            }
            else
            {
                collision.GetComponent<Controller>().velocity = minSpeed;
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Controller>().velocity = oldSpeed;
        }
    }
}
