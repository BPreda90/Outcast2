using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class GameData: MonoBehaviour
{
    public static GameData Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
    
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Outcast Saving Logic

    public string date = "";
    public string time = "";

    public List<Contract> contracts = new List<Contract>();

    public List<Monster> monsters = new List<Monster>();

    public List<Player> _myPlayer = new List<Player>();

    public List<Quests> quest = new List<Quests>();

    public List<Hunter> hunters = new List<Hunter>();

    public List<Bestiary> beasts = new List<Bestiary>();

    public Time savedTime = new Time(1, 1, 1);

    public List<HunterParty> huntingParties = new List<HunterParty>();

    // Hex Saving Logic

    public Dictionary<string, HexMap_Continent> HexMapDictionary = new Dictionary<string, HexMap_Continent>();

    public List<Unit> UnitsOnMap = new List<Unit>();
    
}
