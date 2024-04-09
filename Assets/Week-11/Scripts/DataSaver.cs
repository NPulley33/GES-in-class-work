using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    public const string MONEY_ID = "Money"; //const keyword means value doesn't change- const is implicitly static
    public const string NAME_ID = "Name";
    public const string LEVEL_ID = "Levels Complete";

    public string playerName;
    public int level;
    public float dollars {
        get { return m_dollars; }
        private set
        {
            m_dollars = value;
            PlayerPrefs.SetFloat(MONEY_ID, dollars);
            Debug.Log(PlayerPrefs.GetFloat(MONEY_ID, 0));
        }
    }
    private float m_dollars;
    //public readonly float dollars; //readonly keyword does not allow modificatioin to the variable

    public SaveData SaveData;

    [ContextMenu("Save Data")]
    void SaveDataTest()
    {
        PlayerPrefs.SetInt(LEVEL_ID, 2);
        PlayerPrefs.SetFloat(MONEY_ID, dollars);
        PlayerPrefs.SetString(NAME_ID, playerName);

        Debug.Log(JsonUtility.ToJson(SaveData));
        PlayerPrefs.SetString("SaveData", JsonUtility.ToJson(SaveData));

        //guarentees that modified data saves
        PlayerPrefs.Save();
    }

    [ContextMenu("Load Data")]
    void LoadData()
    {
        //int not required, supplies a default value if no data has been saved yet
        level = PlayerPrefs.GetInt(LEVEL_ID, 1);
        m_dollars = PlayerPrefs.GetFloat(MONEY_ID, 0);
        playerName = PlayerPrefs.GetString(NAME_ID, "No name");

        SaveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString("SaveData"));

    }

    [ContextMenu("Add Dollar")]
    void AddDollar()
    {
        dollars++;
    }

    //notes/thoughts:
    /**
     * can use a single game manager between scenes and carry the data between levels
     * or you can save and load data between scenes
     * could use json savedData as multiple variables to load/have save slots
     * 
     */

}
