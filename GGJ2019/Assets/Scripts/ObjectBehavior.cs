using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    public UnitSO unitSO;

    [HideInInspector]
    public ListSO generatorSO;

    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        if (unitSO)
        {
            sr.sprite = unitSO.ObjectIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {        
        if(sr.enabled == false && unitSO)
        {
            sr.sprite = unitSO.ObjectIcon;
            sr.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Controller controller = other.GetComponent<Controller>();
        if(controller.packSO.units.Count < 2)
        {
            controller.packSO.units.Add(unitSO);
            controller.UpdatePack();
        }
        generatorSO.units.Remove(unitSO);
        Destroy(gameObject);

    }
}
