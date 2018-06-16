using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour {

    static SceneLoader Instance;

    private void Start()
    {
        if(Instance !=null)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            Instance = this;
        }
    }

   public void LoadScene()
    {
        print("Scene Loaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
