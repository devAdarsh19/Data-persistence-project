using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{

    public static DataManager Instance;

    public string playerName;
    public int playerScore = 0;

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
        LoadData();
    }

    [System.Serializable]
    class SavePlayerData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveData()
    {
        SavePlayerData data = new SavePlayerData();
        data.playerName = playerName;
        data.playerScore = playerScore;

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
        }
    }
}
