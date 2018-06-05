using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public enum StateOfLocation { Prosperous, Stagnant, Declining, Corrupt, Abandoned, Overrun }

    public interface IPointOfInterest
    {
        int Corruption { get; set; }
        void SetInitialStateOfLocation(StateOfLocation state);
    }

    public interface IMonsterSpawner
{
    void SpawnMonster();
}

