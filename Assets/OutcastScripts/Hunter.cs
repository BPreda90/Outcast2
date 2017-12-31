using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Hunter {

    string negativeStatError = "A character with a negative stat is impossible.";
    

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
    /// This stat describes how effective a hunter is in close quarters combat
    /// This measures how likely a hunter will hit a monster with hand to hand weapons
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

    /// <summary>
    /// This stat describes how effective a hunter is in ranged combat
    /// This measures how likely a hunter will hit a monster with rifles, grenades, potions
    /// This stat is useful for the ranged hunter that will take potshots at monsters from afar while supported
    /// by tanky comarades that will face the monster head on 
    /// </summary>
    public int Accuracy 
    {
        get
        {
            return _accuracy;
        }
        set
        {
            if (value< 0)
            {
                throw new Exception("Invalid X coordinate passed.");
            }

            _accuracy = value;
        }
    }
    [SerializeField]
    protected int _accuracy;

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
    public int ArkaneKnowledge
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

    /// <summary>
    /// This stat describes the hunter's phisical resiliance
    /// This measures how many blows a hunter can take before succumbing to their injuries.
    /// 
    /// If a hunter takes too many blows, permanent injuries can occur,
    /// affecting their effectiveness in combat.
    /// </summary>
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _health = value;
        }
    }
    [SerializeField]
    protected int _health;

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
    /// This stat describes the hunter's monthyl pay. 
    /// This measures the amount of coin that is deducted from the guild's treasury each month for a hunter's service
    /// Each time a hunter levels up, their pay will also increase
    /// 
    /// A grandmaster should be mindful of the guild's treasury, if the coffers end up empty, 
    /// the hunters will abandon the guild, to seek their fortune elsewere, nobody puts their lives at stakes for free.
    /// 
    /// The game will end if the guild ends up bankrupt.
    /// </summary>
    public float MonthlyPay
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
    protected float _monthlyPay;

    /// <summary>
    /// This stat describes a hunter's personal fortune. A life of adventure can become a life of luxury, 
    /// if a hunter can outlive the dangers.
    /// A hunter may use their fortune to better equip themselves, or relieve themselves of stress.
    /// 
    /// </summary>
    public float Fortune
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
    protected float _fortune;


    
    public Hunter (
                   string name,
                   int strength, int agility, int arkaneKnowledge,
                   int level, int experience, int age, int sanity,
                   float monthlyPay, float fortune
                   )
    {
        this.Name = name;
        this.Strength = strength;
        this.Accuracy = agility;
        this.ArkaneKnowledge = arkaneKnowledge;
        this.Level = level;
        this.Experience = experience;
        this.Age = age;
        this.Health = strength+sanity*level/2-age/10;
        this.Sanity = sanity;

        this.MonthlyPay = monthlyPay;
        this.Fortune = fortune;

      

    }
}
