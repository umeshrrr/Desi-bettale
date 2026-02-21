using UnityEngine;
using System.IO;

namespace DesiShadow.Core
{
    public class SaveManager : Singleton<SaveManager>
    {
        public PlayerData CurrentSaveData;
        private string saveFileName = "playerdata.json";

        protected override void Awake()
        {
            base.Awake();
            LoadGame();
        }

        public void SaveGame()
        {
            string json = JsonUtility.ToJson(CurrentSaveData, true);
            string path = Path.Combine(Application.persistentDataPath, saveFileName);
            File.WriteAllText(path, json);
            
            // Debug log for development only
            Debug.Log($"Game Saved to: {path}");
        }

        public void LoadGame()
        {
            string path = Path.Combine(Application.persistentDataPath, saveFileName);

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                CurrentSaveData = JsonUtility.FromJson<PlayerData>(json);
            }
            else
            {
                Debug.Log("No save file found. Creating new profile.");
                CurrentSaveData = new PlayerData();
                SaveGame();
            }
        }

        // Call this when the app is minimized/closed on Android
        private void OnApplicationPause(bool pause)
        {
            if (pause) SaveGame();
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}
