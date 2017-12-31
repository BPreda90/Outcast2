using UnityEngine;
using System.Collections;

public class Weapon : Item
{
    int Damage { get; set; }

    public Weapon(int id, int damage, string itemName, string pluralName)
        : base(id, itemName, pluralName)
    {
        Damage = damage;
    }
}
