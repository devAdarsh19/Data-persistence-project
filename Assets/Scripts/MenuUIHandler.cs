using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField inputField;
    public TMP_Dropdown playerProfilesDD;


    private void Start()
    {
        PlayerProfilesLoad();
    }

    public void GetName(string name)
    {
        DataManager.Instance.playerName = inputField.text;
        if (!DataManager.Instance.playerProfiles.Contains(inputField.text))
        {
            DataManager.Instance.playerProfiles.Add(inputField.text);
        }
        //Debug.Log(DataManager.Instance.playerProfiles.IndexOf(inputField.text));
    }

    public void StartGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        DataManager.Instance.SaveData();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void PlayerProfilesLoad()
    {
        playerProfilesDD.AddOptions(DataManager.Instance.playerProfiles);
    }

    public void ClearProfiles()
    {
        DataManager.Instance.playerProfiles.Clear();
        DataManager.Instance.playerHighScore.Clear();
        playerProfilesDD.ClearOptions();
        DataManager.Instance.playerScore = 0;
    }

    public void LoadGame()
    {
        DataManager.Instance.LoadData();
        PlayerProfilesLoad();
    }

    public void SaveGame()
    {
        DataManager.Instance.SaveData();
    }

    /*public void GetNameIndex()
    {
        int p_index = DataManager.Instance.index;
        p_index = playerProfilesDD.value;
        inputField.text = DataManager.Instance.playerProfiles[p_index];
        Debug.Log(p_index);
    }*/

    public void ProfileDropDown()
    {
        int p_index = DataManager.Instance.index;
        p_index = playerProfilesDD.value;
        inputField.text = DataManager.Instance.playerProfiles[p_index];
    }
}
