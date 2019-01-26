﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemsSpawner : MonoBehaviour
{
    static CharacterItemsSpawner mInstance;
    public static CharacterItemsSpawner Instance { get { return mInstance; } }

    static bool mIsInited;
    static List<CharacterItem> instancedCharacterItemList = new List<CharacterItem>();

    [SerializeField]
    NPCSO npcSO;

    [SerializeField]
    ListSO characterInfoSO;

    public List<CharacterItem> InstancedCharacterItemList { get { return instancedCharacterItemList; } }


    void OnEnable()
    {
        mInstance = this;

        if (!mIsInited)
        {
            instancedCharacterItemList.Clear();

            foreach (var item in characterInfoSO.units)
            {
                var point = Random.insideUnitCircle;
                point *= npcSO.lengthLimit;

                instancedCharacterItemList.Add(new CharacterItem() { unit = item, targetItem = null, position = point });
            }
        }

        foreach (var item in instancedCharacterItemList)
        {
            var go = new GameObject(item.unit.name + "_item");
            go.transform.SetParent(transform);
            go.transform.position = item.position;
            go.AddComponent<SpriteRenderer>().sprite = item.unit.objectIcon;
            item.targetItem = go;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(Vector3.zero, npcSO.lengthLimit);
    }
}
