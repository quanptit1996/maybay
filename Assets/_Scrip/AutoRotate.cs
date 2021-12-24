using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class AutoRotate : MonoBehaviour
{
    private Rigidbody _rg;
    private float speed = 6;

    private void Awake()
    {
        _rg = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _rg.angularVelocity = Random.insideUnitSphere * speed;
    }

   
    void Update()
    {
        
    }
}
