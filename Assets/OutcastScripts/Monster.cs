using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[System.Serializable]
public class Monster
{
    string negativeStatError = "A character with a negative stat is impossible.";

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
            if (value != Type.Undead || value != Type.Construct || value != Type.PlagueTouched || value != Type.Abberation || value != Type.Human)
        {
                throw new Exception("Monsters have to be part of a predefined Type, please either define new the type in the monster class, or use an existing type");
            }
            _monsterType = value;
        }
    }
    [SerializeField]
    protected Type _monsterType;
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

    /// <summary>
    /// This stat describes how effective a monster is combat
    /// This measures how much damage it applies on each attack
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

    /// <summary>
    /// This stat describes how clever a hunter is
    /// This measures the hunter's ability to track enemies, his ablity to gain new lore,
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

    /// <summary>
    /// This stat describes the creature's abilty to hide from search parties
    /// This measures how smart a creature is and how likely it is for it to ambush a hunting party
    /// </summary>
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
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

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
    public float RangedDamage
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
    protected float _rangedDamage;

    /// <summary>
    /// This stat describes how well a hunter can use a melee weapon
    /// This measures the damage a hunter applies to his standard melee attacks
    /// </summary>
    public float MeleeDamage
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
    protected float _meleeDamage;

    // This stat describes how fast a hunter reacts to his environments 
    // This measures the hunter's abilty to react to special triggers, his turn order in combat
    public float Reactivity
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

    public void SpecialAbilty(Type _type)
    {
        if(_type == Type.Abberation)
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
    [SerializeField]
    protected float _reactivity;


    public Monster(string name, Type _type, int strength,int agility ,int inteligence, int stealth, int maxhealth, int rewardLore, int level)
    {
 
        this.MonsterType = _type;
        this.Name = name;

        this.Level = level;
        this.Strength = strength;
        this.Inteligence = inteligence;
        this.Agility = agility;

        this.Stealth= inteligence + agility / 2;
        this.RewardKnowledge= Level / 2 + inteligence;
        this.MaxHealth = strength + 10 + agility / 2;
        this.CurrentHealth = MaxHealth;
        this.MeleeDamage = 10 + strength / 2;
        this.RangedDamage = 10 + agility / 2;
        this.Reactivity = 10 + agility + level;

        

    }
}
