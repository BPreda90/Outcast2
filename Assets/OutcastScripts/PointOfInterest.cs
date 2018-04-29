using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.OutcastScripts
{
    public abstract class PointOfInterest
    {
        public int Corruption
        {
            get
            {
                return _corruption;
            }
            set
            {
                _corruption = value;
            }
        }
        [SerializeField]
        protected int _corruption;
    

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
        
    }
        [SerializeField]
        public string _name;

        public enum StateOfLocation { Prosperous, Stagnant, Declining, Corrupt, Abandoned, Overrun }

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



    }
}
