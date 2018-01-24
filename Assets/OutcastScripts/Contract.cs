using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Contract
{

    string negativeStatError = "A character with a negative stat is impossible.";

    public List<Monster> MonstersGroup;

    public bool IsActive;


    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length <= 0)
            {
                throw new Exception(negativeStatError);
            }

            _name = value;
        }
    }
    [SerializeField]
    protected string _name;


    public float Reward
    {
        get
        {
            return _reward;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }
            _reward = value;
        }
    }
    [SerializeField]
    protected float _reward;
    /// <summary>
    /// The distance in days hunter need to travle from the guild outpost to the monster location
    /// </summary>

    public int Distance
    {
        get
        {
            return _distance;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }
            _distance = value;
        }
    }
    [SerializeField]
    protected int _distance;

    public float MonstersStealth;
    public float MonsterReactivity;

    public void GetMonstersStats()
    {
        float _stealth = 0;
        float _reactivity = 0;
        foreach (Monster m in MonstersGroup)
        {
            _stealth += UnityEngine.Random.Range(1, m.Stealth) + m.Level;
            _reactivity += m.Reactivity;
        }
        MonstersStealth = _stealth;
        MonsterReactivity = _reactivity;
    }

    public void ClearMonsterStats()
    {
        MonstersStealth = 0;
        MonsterReactivity = 0;
    }


    public Contract(string name, float reward, int distance, List<Monster> m)
    {
        IsActive = false;
        Name = name;
        Reward = reward;
        Distance = distance;
        MonstersGroup = m;

    }

}
