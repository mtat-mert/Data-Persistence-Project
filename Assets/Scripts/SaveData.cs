using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;


[Serializable]
public  class SaveData : MonoBehaviour 
{
    // Start is called before the first frame update
    public static SaveData Instance;
    public string playerName;
    public string highScorePlayerName;
    public int playerScore;

    void Awake()
    { 
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        Load();

        
    }

    public void SetScore(string name, int playerScore)
    {
        if (playerScore > this.playerScore)
        {
            this.playerScore = playerScore;
            this.highScorePlayerName = name;
        }
    }

    [System.Serializable]
    class SaveScore
    {
        public string saveScoreName;
        public int playerScore;
    }
    public void Save()
    {
        SaveScore data = new SaveScore();
        data.saveScoreName = highScorePlayerName;
        data.playerScore = playerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);

    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScore data = JsonUtility.FromJson<SaveScore>(json);
            playerScore = data.playerScore;
            highScorePlayerName = data.saveScoreName;
        }

    }
}
