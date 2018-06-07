using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonData : MonoBehaviour
{
    string filename = "saveData.json";
    public static string path;

    string error = "Unable to retrieve file! The save file might be corrupted or missing!";
    [HideInInspector] public GameData gameData;

    // Use this for initialization
    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, filename);
        Debug.Log(path);
    }

    private void Awake()
    {
        gameData = GetComponent<GameData>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SaveData();
            print("Saved Data");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ReadData();
            print("Read Data");
        }
    }
    public void SaveData()
    {

        JsonWrapper wrapper = new JsonWrapper();
        wrapper.gameData = gameData;


        string contents = JsonUtility.ToJson(wrapper, true);
        File.WriteAllText(path, contents);
    }
    public void ReadData()
    {
        try
        {
            if (File.Exists(path))
            {
                string contents = File.ReadAllText(path);
                JsonWrapper wrapper = JsonUtility.FromJson<JsonWrapper>(contents);
                gameData = wrapper.gameData;


                foreach (Quests q in gameData.quest)
                {
                    Debug.Log(q.desc);
                }
                foreach (Hunter h in gameData.hunters)
                {
                    Debug.Log(h.Name);
                }
            }
            else
            {
                Debug.LogError(error);
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }


}