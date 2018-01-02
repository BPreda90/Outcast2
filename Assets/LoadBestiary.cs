using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBestiary : MonoBehaviour {

    GameData gameData;
	// Use this for initialization
	void Start () {
        TextAsset bestiary = Resources.Load<TextAsset>("Bestiary");
        string[] data = bestiary.text.Split(new char[] {'\n' });
        Debug.Log(data.Length);
        for (int i = 1; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Bestiary b = new Bestiary();
            int.TryParse(row[0], out b.id);
            b.type = row[1];
            b.name = row[2];
            int.TryParse(row[3], out b.level);

            gameData.beasts.Add(b);

        }

        foreach(Bestiary b in gameData.beasts)
        {
            Debug.Log(b.name);
        }
            
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
