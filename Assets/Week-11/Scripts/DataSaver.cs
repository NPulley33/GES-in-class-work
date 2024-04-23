using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
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

        //create a path to save to external file (not relative to resource folder)
        string path = "Assets/Resources/Levels/Level_01.txt";
        //write text to .txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(JsonUtility.ToJson(SaveData));
        writer.Close();
        //re-import the file to update the reference in the editor
        AssetDatabase.ImportAsset(path);


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

        //SaveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString("SaveData"));

        TextAsset ta = Resources.Load("Levels/Level_01") as TextAsset;
        SaveData = JsonUtility.FromJson<SaveData>(ta.text);
        //if done using text asses you can do Resources.UnloadAsset(ta); (memory collection)

        /*
        TextAsset ta2 = Resources.Load("en");
        string contents = ta2.text;

         */
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
