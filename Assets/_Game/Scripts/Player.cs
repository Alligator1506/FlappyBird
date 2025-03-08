using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private bool IsCanUpdate => GameManager.Ins.IsState(GameState.GamePlay);
    SkinType _skinType = SkinType.Skin1;
    
    private float topBoundary = 4.5f;    
    private float bottomBoundary = -4.5f;
    
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
        if (IsCanUpdate)
        {
            Fly();
            Vector3 birdPosition = transform.position;
            birdPosition.y = Mathf.Clamp(birdPosition.y, bottomBoundary, topBoundary);
            transform.position = birdPosition;
        }
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
            UIManager.Ins.CloseAll();
            UIManager.Ins.OpenUI<UIGameOver>();
        }
    }
}
