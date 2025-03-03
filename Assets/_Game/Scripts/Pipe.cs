using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float pipeSpeed = 5f;

    void Update()
    {
        CanMove();
    }

    void CanMove()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;
        if (transform.position.x < -10f) // Khi ra khỏi màn hình
        {
            gameObject.SetActive(false); // Tắt ống để tái sử dụng
        }
    }
}
