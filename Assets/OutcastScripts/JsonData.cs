using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonData : MonoBehaviour
{
    string filename = "saveData.json";
    public static string path;

    string error = "Unable to retrieve file! The save file might be corrupted or missing!";

    GameData gameData = new GameData();

    // Use this for initialization
    void Start()
    {
        path = Path.Combine(Application.persistentDataPath, filename);
        Debug.Log(path);
        GameManager.HunterCreated += HunterRecruited;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveData();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadData();
        }
    }
    public void SaveData()
    {
        JsonWrapper wrapper = new JsonWrapper();
        wrapper.gameData = this.gameData;

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
                Debug.Log(gameData.date + "\n" + gameData.time);

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


    public void HunterRecruited(Hunter h)
    {
        if (!gameData.hunters.Contains(h))
        {
            gameData.hunters.Add(h);
        }
        else
        {
            Debug.LogError(h.Name + "is already present in the user's persistent hunter list! Something went wrong!");
        }
    }

    public void HunterDismissed(Hunter h)
    {
        if (gameData.hunters.Contains(h))
        {
            gameData.hunters.Remove(h);
        }
        else
        {
            Debug.LogError(h.Name + " does not exist inside the user's persistent hunter list");
        }
    }


}