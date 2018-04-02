using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Hunter : Unit
{

    /// <summary>
    /// TODO: Split the stats in primary and derivative. Primary stats, str, int, agil ...
    /// Secondary stats should be derived from the primary stats (Accuracy, Damage, Health...)
    /// 
    /// </summary>
    


    /// <summary>
    ///
    /// The game happens in real time, each turn a day will pass
    /// After a year has passed, all hunters will age
    ///
    /// As hunters age, their phisical and mental strength will sap, those lucky will retire from this life 
    /// those less fortunate will meet their ends in brutal ways carying the Grandmaster's Orders
    ///
    /// Everybody ages, even the grandmaster. As soon as one grandmaster dies of old age/or monster attack, 
    /// another will take his place.
    /// 
    /// </summary>
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _age = value;
        }
    }
    [SerializeField]
    protected int _age;


    // Derived Stats

    /// <summary>
    /// This stat describes the hunter's phisical resiliance
    /// This measures how many blows a hunter can take before succumbing to their injuries.
    /// 
    /// If a hunter takes too many blows, permanent injuries can occur,
    /// affecting their effectiveness in combat.
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
    /// This stat describes the hunter's mental resiliance 
    /// This measures how much mental stress a hunter can take before going mad
    /// 
    /// If a hunter's sanity drops all the way to 0, they will become the monsters they themselves hunted
    /// 
    /// </summary>
    public int Sanity
    {
        get
        {
            return _sanity;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _sanity = value;
        }
    }
    [SerializeField]
    protected int _sanity;

    /// <summary>
    /// This stat describes how effective a hunter is in monster tracking
    /// This measures how likely a hunter will be abel to pinpoint the target monster
    /// </summary>
    public int Tracking
    {
        get
        {
            return _tracking;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Invalid X coordinate passed.");
            }

            _tracking = value;
        }
    }
    [SerializeField]
    protected int _tracking;

    /// <summary>
    /// This stat describes how effective a hunter is in the R&D department
    /// This measures how many reasearch points a hunter offers the team each hunt
    ///
    /// Each succesful monster hunt (at least one hunter returns from a mission) a pool of arkane
    /// points are awarded to the player, as hunters gained a bit of knowledge on monsters:
    /// their habits, their strengths, their weaknesses. 
    ///
    /// The total points awarded to the player from each mission 
    /// is equal to total arkane knowledge of the returning hunters multiplied by monster level
    ///
    /// Arkane knowledge comes with a price as each time a threshhold is reached
    /// the hunter will take a hit in the sanity stat
    /// </summary>
    public int ArkaneNnowledge
    {
        get
        {
            return _arkaneKnowledge;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _arkaneKnowledge = value;
        }
    }
    [SerializeField]
    protected int _arkaneKnowledge;

    /// <summary>
    /// This stat describes the hunter's current level
    /// As a hunter gathers experience past certain threshholds, they will level up
    /// Each level, some stats are boosted according to hunter type, enabling a squad of hunters to 
    /// go for more dangerous targets and better rewards
    /// 
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
    /// Each completed contracts awards the surviving hunters experience points according to monster level
    /// If he accumulated xp passes certain thresholds, hunters will level up
    /// </summary>
    public int Experience
    {
        get
        {
            return _experience;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _experience = value;
        }
    }
    [SerializeField]
    protected int _experience;

    /// <summary>
    /// This stat describes the hunter's monthyl pay. 
    /// This measures the amount of coin that is deducted from the guild's treasury each month for a hunter's service
    /// Each time a hunter levels up, their pay will also increase
    /// 
    /// A grandmaster should be mindful of the guild's treasury, if the coffers end up empty, 
    /// the hunters will abandon the guild, to seek their fortune elsewere, nobody puts their lives at stakes for free.
    /// 
    /// The game will end if the guild ends up bankrupt.
    /// </summary>
    public int MonthlyPay
    {
        get
        {
            return _monthlyPay;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _monthlyPay = value;
        }
    }
    [SerializeField]
    protected int _monthlyPay;

    /// <summary>
    /// This stat describes a hunter's personal fortune. A life of adventure can become a life of luxury, 
    /// if a hunter can outlive the dangers.
    /// A hunter may use their fortune to better equip themselves, or relieve themselves of stress.
    /// 
    /// </summary>
    public int Fortune
    {
        get
        {
            return _fortune;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _fortune = value;
        }
    }
    [SerializeField]
    protected int _fortune;

    // Combat Stats

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

    /// <summary>
    /// This stat describes how well protected a hunter is from monster attacks, the more armor the ranger has and how fast
    /// he reacts to danger, the more protected he is
    /// This measures the damage that is subtracted from any standard monster attack
    /// </summary>
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

    public Hunter(
                   string name,
                   int strength, int inteligence, int agility,
                   int level, int experience, int age, int monthlyPay
                   

                   ): base (name, strength, inteligence, agility )
    {
        // Pirmary Stats
        this.Name = name;

        this.Level = level;
        this.Experience = experience;
        this.Age = age;

        this.MonthlyPay = monthlyPay;

        this.Strength = strength;
        this.Inteligence = inteligence;
        this.Agility = agility;


        this.Tracking = inteligence + agility / 2;
        this.ArkaneNnowledge = Level / 2 + inteligence;
        this.MaxHealth = strength + 10 + agility / 2;
        this.CurrentHealth = MaxHealth;
        this.Sanity = Level / 2 + inteligence;

        this.MeleeDamage = 10 + strength / 2;
        this.RangedDamage = 10 + agility / 2;
        this.Reactivity = 10 + agility + level;
        this.DamageReduction = Reactivity / 3;

        this.Fortune = 0 + monthlyPay;

        this.IsAlive = true;
        this.HasTakenTurn = false;

    }

    //Combat Utility Functions:

}
