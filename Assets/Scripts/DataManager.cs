using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    public string playerName;
    public int playerScore = 0;
    public int index;
    //public bool playerExists;
    public List<string> playerProfiles = new List<string>();
    public List<int> playerHighScore = new List<int>();

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        
    }

    [System.Serializable]
    class SavePlayerData
    {
        public string playerName;
        public int playerScore;
        public int index;
        //public bool playerExists;
        public List<string> playerProfiles;
        public List<int> playerHighscore;
    }

    public void SaveData()
    {
        SavePlayerData data = new SavePlayerData();
        data.playerName = playerName;
        data.playerScore = playerScore;
        data.playerProfiles = playerProfiles;
        data.playerHighscore = playerHighScore;
        data.index = index;
        //data.playerExists = playerExists;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavePlayerData data = JsonUtility.FromJson<SavePlayerData>(json);

            playerName = data.playerName;
            playerScore = data.playerScore;
            playerProfiles = data.playerProfiles;
            playerHighScore = data.playerHighscore;
            index = data.index;
            //playerExists = data.playerExists;
        }
    }
}
