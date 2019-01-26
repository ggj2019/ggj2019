using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterItemsSpawner : MonoBehaviour
{
    static bool mIsInited;

    [SerializeField]
    NPCSO npcSO;

    [SerializeField]
    CharacterItemSO instancedCharacterItemSO;

    [SerializeField]
    ListSO characterInfoSO;

    public CharacterItemSO InstancedCharacterItemSO { get { return instancedCharacterItemSO; } }


    void OnEnable()
    {
        if (!mIsInited)
        {
            instancedCharacterItemSO.items.Clear();

            foreach (var item in characterInfoSO.units)
            {
                var point = Random.insideUnitCircle;
                point *= npcSO.lengthLimit;

                instancedCharacterItemSO.items.Add(new CharacterItemSO.ItemInfo() { unit = item, targetItem = null, position = point });
            }
        }

        foreach (var item in instancedCharacterItemSO.items)
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
