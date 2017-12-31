using UnityEngine;
using System.Collections;

public class HealingPowder : Item
{
    int HealthAmount { get; set; }

    public HealingPowder(int id, int healthAmount, string itemName, string pluralName)
        : base(id, itemName, pluralName)
    {
        HealthAmount = healthAmount;
    }
}
