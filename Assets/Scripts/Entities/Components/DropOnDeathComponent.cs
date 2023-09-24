using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

[System.Serializable]
public class DropOnDeathComponent 
{
    public Item itemDroppedOnDeath = null;

    public void CreateItemOnDeath(Vector3 positionOnDeath)
    {
        if (itemDroppedOnDeath != null)
        {
            GameObject.Instantiate(PrefabManager.CollectibleItemPrefab, positionOnDeath, Quaternion.identity).GetComponent<CollectableObject>().storedItem = itemDroppedOnDeath;
        }
    }
}
