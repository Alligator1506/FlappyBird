using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private LayerMask groundLayer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.NameToLayer("Ground");
    }

    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
            AudioManager.instance.Play("wing");
        }
    }
    
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            AudioManager.instance.Play("hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }
}
