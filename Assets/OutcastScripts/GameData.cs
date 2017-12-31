using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public string date = "";
    public string time = "";

    public Player _myPlaceholderPlayer;
    
    public List<Quests> quest = new List<Quests>();

    public List<Hunter> hunters = new List<Hunter>();
    
}
