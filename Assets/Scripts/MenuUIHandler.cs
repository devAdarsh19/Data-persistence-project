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


    public void GetName(string name)
    {
        DataManager.Instance.playerName = inputField.text;
        Debug.Log(DataManager.Instance.playerName);
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
}
