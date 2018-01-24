using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBestiary : MonoBehaviour
{

   public Main main;

    // Use this for initialization
    void Start()
    {
        main = FindObjectOfType<Main>();
        TextAsset bestiary = Resources.Load<TextAsset>("Bestiary - Sheet1");
        string[] data = bestiary.text.Split(new char[] { '\n' });
        Debug.Log(data.Length);
        Debug.Log(data);
        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });


            Monster m = new Monster(row[1], row[2], int.Parse(row[3]), int.Parse(row[4]), int.Parse(row[5]), int.Parse(row[6]),
                        int.Parse(row[7]), int.Parse(row[8]));

            main.jData.gameData.monsters.Add(m);
            
        }
    }
     



    // Update is called once per frame
    void Update()
    {

    }

}