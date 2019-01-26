using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectOnDisableFix : MonoBehaviour
{
    [SerializeField]
    ScriptableObject[] scriptableObjects;


    void OnDisable()
    {
        for (int i = 0; i < scriptableObjects.Length; i++)
        {
            var item = scriptableObjects[i];

            var constructorInfoArray = item.GetType().GetMethods(System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Public);

            var onDisable = constructorInfoArray.FirstOrDefault(m => m.Name == "SaveValue");
            if (onDisable != null)
                onDisable.Invoke(item, null);
        }
    }
}
