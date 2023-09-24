using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SerializableEnemyData : SerializableEntityData
    {
        public float CurrentHP;

        public void UnloadDataToObject(Enemy enemyToUnloadData)
        {
            enemyToUnloadData.transform.position = new Vector3(PositionX, PositionY, 0);

            enemyToUnloadData.CurrentHP = CurrentHP;
            enemyToUnloadData.RecieveDamage(0);
        }
        public static SerializableEnemyData GetDataToSave(Enemy enemyToSaveData)
        {
            SerializableEnemyData serializableEnemyData = new SerializableEnemyData
            {
                CurrentHP = enemyToSaveData.CurrentHP,
                PositionX = enemyToSaveData.transform.position.x,
                PositionY = enemyToSaveData.transform.position.y
            };

            return serializableEnemyData;
        }
    }
}
