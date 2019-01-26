using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CharacterItemSO")]
public class CharacterItemSO : ScriptableObject
{
    [Serializable]
    public class ItemInfo
    {
        public UnitSO unit;
        public GameObject targetItem;
        public Vector3 position;
    }

    public List<ItemInfo> items = new List<ItemInfo>();
}