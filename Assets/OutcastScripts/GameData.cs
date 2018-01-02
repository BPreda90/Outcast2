using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData
{

    public string date = "";
    public string time = "";


    public Player _myPlaceholderPlayer;
    
    public List<Quests> quest = new List<Quests>();

    public List<Hunter> hunters = new List<Hunter>();

    public List<Bestiary> beasts = new List<Bestiary>();

    public Time savedTime = new Time(1,1,1);

}
