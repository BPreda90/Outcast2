using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class LegacyUnit
{
   protected string negativeStatError = "A character with a negative stat is impossible.";
    // Primary Stats

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


    public bool HasTakenTurn
    {
        get
        {
            return _hasTakenTurn;
        }
        set
        {
            _hasTakenTurn = value;
        }
    }
        [SerializeField]
        protected bool _hasTakenTurn;


    public bool IsAlive   
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
        }
    }
    [SerializeField]
    protected bool _isAlive;
    
    
    /// <summary>
    /// This stat describes how effective a unit is in close quarters combat
    /// This measures the hunter's melee damage, part of his health, 
    /// 
    /// This stat will also passively increase the hunter's health each level
    /// 
    /// This stat is useful for melee hunter that will face monsters head on while 
    /// the ranged hunter kills it from safety of the back row
    /// </summary>
    public int Strength
    {
        get
        {
            return _strength;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _strength = value;
        }
    }
    [SerializeField]
    protected int _strength;

    public int ModifierStrength
    {
        get
        {
            return _modifierStrength;
        }
        set
        {
            _modifierStrength = value;
        }
    }
    [SerializeField]
    protected int _modifierStrength;
    /// <summary>
    /// This stat describes how clever a unit is
    /// This measures the unit's ability to track or hide from enemies, his ablity to gain new lore,
    /// his arkane abilities
    /// </summary>
    public int Inteligence
    {
        get
        {
            return _inteligence;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _inteligence = value;
        }
    }
    [SerializeField]
    protected int _inteligence;

    public int ModifierInteligence
    {
        get
        {
            return _modifierInteligence;
        }
        set
        {
            _modifierInteligence = value;
        }
    }
    [SerializeField]
    protected int _modifierInteligence;

    /// <summary>
    /// This describes how nimble a hunter is
    /// This stat measures the hunter's ability to use ranged weapons, evade attacks,  
    /// </summary>
    public int Agility
    {
        get
        {
            return _agility;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _agility = value;
        }
    }
    [SerializeField]
    protected int _agility;

    public int ModifierAgility
    {
        get
        {
            return _modifierAgility;
        }
        set
        {
            _modifierAgility = value;
        }
    }
    [SerializeField]
    protected int _modifierAgility;


    public LegacyUnit(string name, int strength, int inteligence, int agility)
    {

    }

    public LegacyUnit()
    {

    }

    public int AIActionDecision()
    {
        int decision = UnityEngine.Random.Range(0, 2);
        return decision;
    }
}