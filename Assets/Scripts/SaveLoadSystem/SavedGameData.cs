using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoadSystem
{
    [System.Serializable]
    public class SavedGameData
    {
        public SerializablePlayerData PlayerData;
        public List<SerializableEnemyData> EnemiesData = new List<SerializableEnemyData>();
    }
}
