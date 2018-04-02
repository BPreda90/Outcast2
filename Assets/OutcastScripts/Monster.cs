using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Monster: Unit
{

    /// <summary>
    /// Describes the monster type. A certain type would have some special characteristics
    /// Undead have the ability to regenerate
    /// Constructs are very tough
    /// Plague Touched have the abilty to poison
    /// Abberations have multiple attacks in a turn
    /// </summary>
    public enum Type { Undead, Construct, PlagueTouched, Abberation, Human }

    public Type MonsterType
    {
        get
        {
            return _monsterType;
        }
        set
        {
            _monsterType = value;
        }
    }
    [SerializeField]
    protected Type _monsterType;


    public int Stealth
    {
        get
        {
            return _stealth;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Invalid X coordinate passed.");
            }

            _stealth = value;
        }
    }
    [SerializeField]
    protected int _stealth;

    /// <summary>
    /// This stat describes a creature's toughness
    /// This measures how much damage a creature can take before it succumbs to its wounds
    /// </summary>
    public int CurrentHealth
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }
    [SerializeField]
    protected int _currentHealth;

    /// <summary>
    /// This stat describes a creature's toughness
    /// This measures how much damage a creature can take before it succumbs to its wounds
    /// </summary>
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _maxHealth = value;
        }
    }
    [SerializeField]
    protected int _maxHealth;




    /// <summary>
    /// This stat describes the experience gained by the party after a successful hunt
    /// This measures the Lore points and XP points a party gains after a successful hunt 
    /// </summary>
    public int RewardKnowledge
    {
        get
        {
            return _rewardLore;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _rewardLore = value;
        }
    }
    [SerializeField]
    protected int _rewardLore;

    /// <summary>
    /// This stat describes the monster's level
    /// This measures how challenging a monster encounter is. 
    /// </summary>
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _level = value;
        }
    }
    [SerializeField]
    protected int _level;

    /// <summary>
    /// This stat describes how well a hunter can use a ranged weapon
    /// This measures the damage a hunter applies to his standard ranged attacks
    /// </summary>
    public int RangedDamage
    {
        get
        {
            return _rangedDamage;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }
            _rangedDamage = value;
        }
    }
    [SerializeField]
    protected int _rangedDamage;

    /// <summary>
    /// This stat describes how well a hunter can use a melee weapon
    /// This measures the damage a hunter applies to his standard melee attacks
    /// </summary>
    public int MeleeDamage
    {
        get
        {
            return _meleeDamage;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }
            _meleeDamage = value;
        }
    }
    [SerializeField]
    protected int _meleeDamage;

    // This stat describes how fast a hunter reacts to his environments 
    // This measures the hunter's abilty to react to special triggers, his turn order in combat
    public int Reactivity
    {
        get
        {
            return _reactivity;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }
            _reactivity = value;

        }
    }
    [SerializeField]
    protected int _reactivity;


    public int DamageReduction
    {
        get
        {
            return _damageReduction;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }
            _damageReduction = value;
        }
    }
    [SerializeField]
    protected int _damageReduction;



    


    public Monster(string name, Type _type, int strength, int agility, int inteligence, int maxhealth, int rewardLore, int level)
                        : base (name, strength, inteligence, agility)
    {
        this.Name = name;
        this.MonsterType = _type;
        this.Level = level;
        this.Strength = strength;
        this.Inteligence = inteligence;
        this.Agility = agility;

        this.Stealth = inteligence + agility / 2;
        this.RewardKnowledge = Level / 2 + inteligence;
        this.MaxHealth = strength + 10 + agility / 2;
        this.CurrentHealth = MaxHealth;
        this.MeleeDamage = 10 + strength / 2;
        this.RangedDamage = 10 + agility / 2;
        this.Reactivity = 10 + agility + level;
        this.DamageReduction = Reactivity / 3;
        this.IsAlive = true;
        this.HasTakenTurn = false;
    }


    public Monster(string name, string _type, int strength, int agility, int inteligence, int maxhealth, int rewardLore, int level)
                   :base (name, strength, inteligence, agility)
    {
        Type mType;

        switch (_type)
        {
            case "Undead":
                mType = Type.Undead;
                this.MonsterType = mType;
                break;
            case "Abberation":
                mType = Type.Abberation;
                this.MonsterType = mType;
                break;
            case "Construct":
                mType = Type.Construct;
                this.MonsterType = mType;
                break;
            case "Human":
                mType = Type.Human;
                this.MonsterType = mType;
                break;
            case "PlagueTouched":
                mType = Type.PlagueTouched;
                this.MonsterType = mType;
                break;
        }


       
        this.Name = name;
        this.Level = level;
        this.Strength = strength;
        this.Inteligence = inteligence;
        this.Agility = agility;

        this.Stealth = inteligence + agility / 2;
        this.RewardKnowledge = Level / 2 + inteligence;
        this.MaxHealth = strength + 10 + agility / 2;
        this.CurrentHealth = MaxHealth;
        this.MeleeDamage = 10 + strength / 2;
        this.RangedDamage = 10 + agility / 2;
        this.Reactivity = 10 + agility + level;
        this.DamageReduction = Reactivity / 3;
        this.IsAlive = true;
        this.HasTakenTurn = false;
    }

    //Combat Utility Functions:
    

 

    public void SpecialAbilty(Type _type)
    {
        if (_type == Type.Abberation)
        {

        }
        else if (_type == Type.Construct)
        {

        }
        else if (_type == Type.Human)
        {

        }
        else if (_type == Type.PlagueTouched)
        {

        }
        else if (_type == Type.Undead)
        {

        }
    }
}



