using UnityEngine;
using System.Collections;

public class Hero : Unit
{
    public int XP                   { get; set; }
    public int Level                { get; set; }
    public int Gold                 { get; set; }

    public Hero(string name, int currentHealth, int maxHealth, int xp, int gold, int level )
        : base (name, currentHealth, maxHealth)
    {
        XP = xp;
        Level = level;
        Gold = gold;
    }
}
