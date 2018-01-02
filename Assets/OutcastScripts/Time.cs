using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Time
{
    string negativeStatError = "Something went wrong, this value does not make sense to be negative!";

    public int Day
    {
        get
        {
            return _day;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _day = value;
        }
    }
    [SerializeField]
    protected int _day;

    public int Month
    {
        get
        {
            return _month;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _month = value;
        }
    }
    [SerializeField]
    protected int _month;

    public int Year
    {
        get
        {
            return _year;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception(negativeStatError);
            }

            _year = value;
        }
    }
    [SerializeField]
    protected int _year;


    public Time(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public void NextDay( Time time)
    {
        if (Day == 28 && Month == 2 && Year % 4 != 0)
        {
            time.Day = 1;
            time.Month++;
        }
        else if (Day == 30 && (Month == 4 || Month == 6 || Month == 9 || Month == 11)){
            time.Day = 1;
            time.Month++;
        }
        else if (Day == 31 &&(Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8
            || Month == 10))
        {
            time.Day = 1;
            time.Month++;
        }
        else if (Day == 31 && Month == 12)
        {
            time.Day = 1;
            time.Month = 1;
            time.Year++;
        }
        else
        {
            time.Day++;
        }
    }

}

