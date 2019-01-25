using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public ListSO generatorSO;

    public GameObject objTemplete;

    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < generatorSO.units.Count; i++)
        {
            temp = Instantiate(objTemplete);
            temp.transform.position += new Vector3(1, 0, 0) * i;
            ObjectBehavior objBe = temp.GetComponent<ObjectBehavior>();
            objBe.unitSO = generatorSO.units[i];
            objBe.generatorSO = generatorSO;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
