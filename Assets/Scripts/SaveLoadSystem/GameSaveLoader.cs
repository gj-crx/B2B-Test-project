using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

using Zenject;

namespace SaveLoadSystem
{
    public class GameSaveLoader
    {
        private EnemyFactory enemyFactory;
        private PlayerObject playerObject;
        private DataBase dataBaseToSave;

        [Inject]
        private GameSaveLoader(EnemyFactory enemyFactory, PlayerObject playerObject, DataBase dataBaseToSave)
        {
            this.enemyFactory = enemyFactory;
            this.playerObject = playerObject;
            this.dataBaseToSave = dataBaseToSave;
        }
        public void SaveGameState()
        {
            SavedGameData savedGame = new SavedGameData();

            //Serializing data
            foreach (var enemy in dataBaseToSave.EnemyObjectsPool)
            {
                if (enemy != null) savedGame.EnemiesData.Add(SerializableEnemyData.GetDataToSave(enemy));
            }
            savedGame.PlayerData = SerializablePlayerData.GetDataToSave(dataBaseToSave.PlayerObject);

            //Saving data to file
            SerializationManager.Save("LastGameSave", savedGame);
        }
        public bool LoadGame()
        {
            SavedGameData loadedSave = (SavedGameData)SerializationManager.Load("LastGameSave");
            if (loadedSave == null) return false;

            foreach (var enemyData in loadedSave.EnemiesData)
            {
                var loadedEnemy = enemyFactory.Create();
                enemyData.UnloadDataToObject(loadedEnemy);
            }
            loadedSave.PlayerData.UnloadDataToObject(playerObject);

            return true;
        }
    }
}
