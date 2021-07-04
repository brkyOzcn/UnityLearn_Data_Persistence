using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler instance;
    public string playerName;
    public int bestScore = 0;
    public string bestScorePlayerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadAll();
    }

    public void SetBestScore(int score)
    {
        if (score >= bestScore)
        {
            bestScore = score;
            bestScorePlayerName = playerName;
        }

    }


    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    public void SaveAll()
    {
        SaveData data = new SaveData();
        data.playerName = bestScorePlayerName;
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadAll()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            bestScorePlayerName = data.playerName;
            bestScore = data.bestScore;
        }
    }
}
