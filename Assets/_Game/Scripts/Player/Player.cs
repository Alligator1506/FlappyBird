using UnityEngine;

public class Player : Character
{
    private Rigidbody2D rb;
    private LayerMask groundLayer;
    public float jumpForce = 5f;
    
    private float topBoundary = 4.5f;    
    private float bottomBoundary = -4.5f;
    private Vector3 initialPosition; // Lưu trữ vị trí ban đầu
    private bool IsCanUpdate => GameManager.Ins.IsState(GameState.GamePlay) && !GameManager.GamePaused;
    
    SkinType skinType = SkinType.Skin1;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundLayer = LayerMask.NameToLayer("Ground");
        
        initialPosition = transform.position;
        
        // Set initial body type to static to prevent falling
        SetRigidbodyState(false);
    }

    private void Update()
    {
        if (IsCanUpdate)
        {
            Fly();
            Vector3 birdPosition = TF.position;
            birdPosition.y = Mathf.Clamp(birdPosition.y, bottomBoundary, topBoundary);
            TF.position = birdPosition;
        }
        else if (GameManager.Ins.IsState(GameState.Ready) && Input.GetMouseButtonDown(0))
        {
            // This will be handled by GameManager.Update
        }
    }

    // Set the rigidbody state based on gameplay
    private void SetRigidbodyState(bool isActive)
    {
        if (rb != null)
        {
            // Reset velocity before changing to static
            if (!isActive)
            {
                // Only reset velocity if currently dynamic
                if (rb.bodyType == RigidbodyType2D.Dynamic)
                {
                    rb.velocity = Vector2.zero;
                }
            }
            
            // If active (gameplay), set to dynamic; otherwise, set to static
            rb.bodyType = isActive ? RigidbodyType2D.Dynamic : RigidbodyType2D.Static;
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
    
    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.layer == groundLayer)
        {
            AudioManager.instance.Play("hit");
            UIManager.Ins.CloseAll();
            UIManager.Ins.OpenUI<UIGameOver>();
        }
    }

    public override void OnInit()
    {
        OnTakeClothsData();

        transform.position = initialPosition;    
        // Reset velocity
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }

        base.OnInit();
    }
    
    public override void WearClothes()
    {
        base.WearClothes();
        ChangeSkin(skinType);
    }
    
    public override void OnDeath()
    {
        base.OnDeath();
    }

    internal void OnTakeClothsData()
    {
        skinType = UserData.Ins.playerSkin;
    }
    
    // Subscribe to game state changes
    private void OnEnable()
    {
        // Listen for game state changes
        GameManager.OnGameStateChanged += HandleGameStateChanged;
    }
    
    private void OnDisable()
    {
        // Unsubscribe when disabled
        GameManager.OnGameStateChanged -= HandleGameStateChanged;
    }
    
    // Handle game state changes
    private void HandleGameStateChanged(GameState newState)
    {
        // Set rigidbody to dynamic only during gameplay
        SetRigidbodyState(newState == GameState.GamePlay);
    }
}