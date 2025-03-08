using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : GameUnit
{
    public float pipeSpeed = 5f;

    void Update()
    {
        CanMove();
    }

    void CanMove()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }
}
