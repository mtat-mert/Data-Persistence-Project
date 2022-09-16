using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandle : MonoBehaviour
{
    public string playerName;
    public Text nameField;

    public void StartNew()
    {
        nameField = GameObject.Find("InputFieldText").GetComponent<Text>();
        SetName(nameField.text);
        SceneManager.LoadScene(1);      
    }

    public void Exit()
    {
        SaveData.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void SetName(string name)
    {
        SaveData.Instance.playerName = name;
    }


}
