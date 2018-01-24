using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class HunterParty : MonoBehaviour
{
    public List<Hunter> HuntParty = new List<Hunter>();
    public Contract activeContract = null;
    public Unit activeUnit;
    public Hunter activeHunter;
    public Monster activeMonster;

    public float PartyStrength;
    public float PartyTracking;
    public float PartyLore;
    public float PartyLevel;
    public float PartyReactivity;

    public void GetPartyStats ()
    {
    float _strenght = 0;
    float _tracking = 0;
    float _lore = 0;
    float _level = 0;
    float _reactivity = 0;
        
        foreach (Hunter h in HuntParty)
        {
            _strenght += h.Strength;
            _tracking +=Random.Range(1, h.Tracking) + h.Level;
            _lore += h.ArkaneNnowledge;
            _level += h.Level;
            _reactivity += h.Reactivity; 
        }

        PartyStrength = _strenght;
        PartyTracking = _tracking;
        PartyLore = _lore;
        PartyLevel = _level;
        PartyReactivity = _reactivity;
    }

    public void ClearPartyStats()
    {
        PartyStrength = 0;
        PartyTracking = 0;
        PartyLore = 0;
        PartyLevel = 0;
        PartyReactivity = 0;
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
