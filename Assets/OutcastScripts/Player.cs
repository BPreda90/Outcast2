using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


[System.Serializable]
public class Player
{
    //Sanity check errors
    //string negativeStatError = "A character with a negative stat is impossible.";
    string nameNotSetError = "The character's name cannot be null!";
    string negativeIncomeExpenses = "Income/Expenses has reached a negative value. Something went wrong. The minimum value for each is 0";

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
                throw new Exception(nameNotSetError);
            }

            _name = value;
        }
    }
    [SerializeField]
    protected string _name;

    public float Fortune
    {
        get
        {
            return _fortune;
        }
        set
        {
            _fortune = value;
        }
    }
    [SerializeField]
    protected float _fortune;

    public float Income
    {
        get
        {
            return _income;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeIncomeExpenses);
            }
            _income = value;
        }
    }
    [SerializeField]
    protected float _income;

    public float Expenses
    {
        get
        {
            return _expenses;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeIncomeExpenses);
            }
            _expenses = value;
        }
    }
    [SerializeField]
    protected float _expenses;

    public Player()
    {
        
    }

    public Player(string name, float fortune, float income, float expenses)
    {
        Name = name;
        Fortune = fortune;
        Income = income;
        Expenses = expenses;
    }

    
}

