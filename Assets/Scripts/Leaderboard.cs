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
}
