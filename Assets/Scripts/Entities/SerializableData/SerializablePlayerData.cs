using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InventoryModule;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SerializablePlayerData : SerializableEntityData
    {
        public float CurrentHP;
        public List<int> StoredItemIDs;


        public void UnloadDataToObject(PlayerObject playerToUnloadData)
        {
            playerToUnloadData.transform.position = new Vector3(PositionX, PositionY, 0);

            playerToUnloadData.CurrentHP = CurrentHP;
            playerToUnloadData.RecieveDamage(0);

            //Loading inventory
            for (int i = 0; i < StoredItemIDs.Count; i++)
            {
                playerToUnloadData.Collect(ItemsManager.ItemTypes[StoredItemIDs[i]]);
            }
        }
        public static SerializablePlayerData GetDataToSave(PlayerObject playerToSaveData)
        {
            SerializablePlayerData serializablePlayerData = new SerializablePlayerData
            {
                CurrentHP = playerToSaveData.CurrentHP,
                PositionX = playerToSaveData.transform.position.x,
                PositionY = playerToSaveData.transform.position.y,
                StoredItemIDs = playerToSaveData.PlayerInventory.GetListOfItemIDs()
            };

            return serializablePlayerData;
        }
    }
}
