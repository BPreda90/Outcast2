using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HunterParty : MonoBehaviour
{
    public List<Hunter> HuntParty = new List<Hunter>();
    public Contract activeContract = null;

    public float PartyStrength;
    public float PartyAccuracy;
    public float PartyLore;
    public float PartyLevel;
    
    public void GetPartyStats ()
    {
    float _strenght = 0;
    float _accuracy = 0;
    float _lore = 0;
    float _level = 0;
    
        
        foreach (Hunter h in HuntParty)
        {
            _strenght += h.Strength;
            _accuracy += h.Tracking;
            _lore += h.ArkaneNnowledge;
            _level += h.Level;
        }

        PartyStrength = _strenght;
        PartyAccuracy = _accuracy;
        PartyLore = _lore;
        PartyLevel = _level;
    }

    public void ClearPartyStats()
    {
        PartyStrength = 0;
        PartyAccuracy = 0;
        PartyLore = 0;
        PartyLevel = 0;
    }


    public void TrackMonster() { }

    public void HuntMonster (Monster m)
    {
        TrackMonster();
    }
    
    public void InstantiateParty()
    {
        
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
