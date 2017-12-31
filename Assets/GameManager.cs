using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void OnHunterCreated(Hunter h);
    public static event OnHunterCreated HunterCreated;


    int _placeholderHunterCounter = 0;
    Player _placeholderPlayer = new Player("_placeholderPlayer", 100, 10, 10);

 
    public void GenerateRangedHunter()
    {
        Hunter h = new Hunter("Placeholder_Hunter_" + _placeholderHunterCounter.ToString(), 1, 3, 1, 1, 0, 23, 7, 10, 10);
        _placeholderHunterCounter++;
        _placeholderPlayer.Fortune -= h.MonthlyPay;
        HunterCreated(h);
    }

    public void GenerateMeleeHunter()
    {
        Hunter h = new Hunter("Placeholder_Hunter_" + _placeholderHunterCounter.ToString(), 3, 1, 1, 1, 0, 23, 7, 10, 10);
        _placeholderHunterCounter++;
        _placeholderPlayer.Fortune -= h.MonthlyPay;
        HunterCreated(h);
    }

    public void RemoveHunter(Hunter h)
    {

    }

}
