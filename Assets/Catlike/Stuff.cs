﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : MonoBehaviour {

   public Rigidbody Body { get; private set; }

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
    }
}