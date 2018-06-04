using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.OutcastScripts
{

    public enum StateOfLocation { Prosperous, Stagnant, Declining, Corrupt, Abandoned, Overrun }

    public interface PointOfInterest
    {
        int corruption { get; set; }
        void setInitialLocation(StateOfLocation mylocation);

    }
}
