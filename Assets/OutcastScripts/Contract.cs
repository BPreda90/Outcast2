using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "NewContract",menuName = "Contract")]
public class Contract : ScriptableObject
{

    string negativeStatError = "A character with a negative stat is impossible.";
    public List<Monster> monster;

    public bool IsActive;

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
    private float _reward;
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
    private int _distance;

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
}
