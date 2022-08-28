using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Unity;
using System;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance;
    public string LeaderName;
    public int LeaderScore;
    public int Score;
    public string DateEntry;
    public bool IsBestScore;


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
    class SaveData
    {
        public string LeaderName;
        public int LeaderScore;
        public string DateEntry; 
    }

    public void SaveLeader()
    {
        SaveData data = new SaveData();
        data.LeaderName = LeaderName;
        data.LeaderScore = LeaderScore;
        data.DateEntry = DateTime.Now.ToShortDateString();

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        LoadLeader();
    }

    public void LoadLeader()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            LeaderName = data.LeaderName;
            LeaderScore = data.LeaderScore;
            DateEntry = data.DateEntry;
        }
    }
}
