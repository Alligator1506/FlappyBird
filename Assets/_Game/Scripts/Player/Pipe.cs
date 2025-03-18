using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : GameUnit
{
    public float pipeSpeed = 3f;

    void Update()
    {
        // Only move if the game is not paused
        if (!GameManager.GamePaused)
        {
            CanMove();
        }
    }

    void CanMove()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
    }
}
