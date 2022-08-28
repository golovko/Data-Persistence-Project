using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using File = System.IO.File;

public class Leaderboard : MonoBehaviour
{
    public TMP_Text leaderListText;
    public TMP_InputField inputLeaderName;

    public GameObject nameField;
    public GameObject saveButton;

    private void Start()
    {

        if (GlobalManager.Instance.IsBestScore == true)
        {
            nameField.SetActive(true);
            saveButton.SetActive(true);
            GlobalManager.Instance.IsBestScore = false;
        }
        ShowLiderList();
    }

    public void BackButton()
    {
        Destroy(GameObject.Find("MainManager"));
        SceneManager.LoadScene(0);
    }

    public void ClearButton()
    {
        leaderListText.text = "No entry";
        File.Delete(Application.persistentDataPath + "/savefile.json");
        GlobalManager.Instance.LeaderName = null;
        GlobalManager.Instance.LeaderScore = 0;
        ShowLiderList();
    }

    public void InputLeaderName()
    {
        string textInputField = inputLeaderName.text;
        GlobalManager.Instance.LeaderName = textInputField;
        GlobalManager.Instance.LeaderScore = GlobalManager.Instance.Score;
        GlobalManager.Instance.SaveLeader();
        nameField.SetActive(false);
        saveButton.SetActive(false);
        ShowLiderList();
    }

    private void ShowLiderList()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string text = GlobalManager.Instance.LeaderName + " " + GlobalManager.Instance.LeaderScore + " " + GlobalManager.Instance.DateEntry + "\n";
            leaderListText.text = text;
        }
        else
        {
            leaderListText.text = "No entry";
        }
    }

    //private void AddEntry(string leaderName, int leaderScore = 0)
    //{
    //    Leader entry = new()
    //    {
    //        leaderName = leaderName,
    //        leaderScore = leaderScore,
    //        dateEntry = DateTime.Now
    //    };
    //    leaderList.Add(entry);
    //    SaveData(entry);
    //    //todo add sorting by score, limit entryList by 5 elements

    //    ShowLiderList();
    //}

    //private void ReadData()
    //{

    //    string path = Application.persistentDataPath + "/savefile.json";
    //    if (File.Exists(path))
    //    {
    //        leaderList.Clear();
    //        string json = File.ReadAllText(path);
    //        Leader data = JsonUtility.FromJson<Leader>(json);
    //        leaderList.Add(data);
    //    }
    //}

    //private void SaveData(Leader leader)
    //{

    //    string json = JsonUtility.ToJson(leader);

    //    File.AppendAllText(Application.persistentDataPath + "/savefile.json", json);

    //}

    //private void BestScore()
    //{
    //    int index = 0;
    //    int a = leaderList[0].leaderScore;
    //    //for (int i = 0; i < leaderList.Capacity; i++)
    //    //{

    //    //    if (a < leaderList[i].leaderScore)
    //    //    {
    //    //        a = leaderList[i].leaderScore;
    //    //        index = i;
    //    //    }
    //    //}
    //    GlobalManager.Instance.BestScoreAmount = a;
    //    GlobalManager.Instance.BestScoreName = leaderList[index].leaderName;
    //}

    // experiment


    //void SaveToFile()
    //{
    //    MyList listClass = new MyList();
    //    var outputString = JsonUtility.ToJson(listClass);
    //    File.WriteAllText(Application.persistentDataPath + "/savefile.json", outputString);
    //}

    //void ReadFromFile()
    //{
    //    //In reverse, you can deserialize anything doing this:
    //    var inputString = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
    //    MyList list = JsonUtility.FromJson<MyList>(inputString);

    //}
}

//[Serializable]
//public class Leader
//{
//    public string leaderName { get; set; }
//    public int leaderScore { get; set; }
//    public Guid leaderId;
//    public DateTime dateEntry;

//}

//[Serializable]
//public class MyList
//{
//    public List<Leader> list;
//}

