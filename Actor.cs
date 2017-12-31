using UnityEngine;
using System.Collections;
using System;

public class Actor : MonoBehaviour
{
    public ActorData data = new ActorData();

    public string name = "actor";
    public float health = 10;

    public void StoreData()
    {
        data.name = name;
        data.pos = transform.position;
        data.health = health;
    }

    public void LoadData()
    {
        name = data.name;
        transform.position = data.pos;
        health = data.health;
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}

[System.Serializable]
public class ActorData
{
    public string name;
    public Vector2 pos;
    public float health;

}
