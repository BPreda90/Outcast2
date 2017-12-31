using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit {

    public string Name          { get; set; }
    public int CurrentHealth    { get; set; }
    public int MaxHealth        { get; set; }


    public Unit (string name, int currentHealth, int maxHealth)
    {
        Name = name;
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
        
    }
 
    
}



