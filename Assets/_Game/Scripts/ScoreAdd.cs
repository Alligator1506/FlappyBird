using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    public static ScoreAdd Instance { get; private set; } // Singleton

    [SerializeField] private Sprite[] digitSprites; // Mảng chứa sprite từ 0-9
    [SerializeField] private GameObject digitPrefab; // Prefab của GameObject có SpriteRenderer
    [SerializeField] private Transform scoreDisplay; // Transform của GameObject cha (ScoreDisplay)

    private int score = 0;
    private GameObject[] currentDigits; // Lưu các GameObject hiện tại để cập nhật

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Tránh trùng lặp
        }
    }

    void Start()
    {
        UpdateScoreDisplay();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreDisplay();
    }

    void UpdateScoreDisplay()
    {
        if (currentDigits != null)
        {
            foreach (GameObject digit in currentDigits)
            {
                Destroy(digit);
            }
        }

        char[] digits = score.ToString().ToCharArray();
        currentDigits = new GameObject[digits.Length];

        for (int i = 0; i < digits.Length; i++)
        {
            int digitValue = int.Parse(digits[i].ToString());
            GameObject digitObj = Instantiate(digitPrefab, scoreDisplay);
            digitObj.transform.localPosition = new Vector3(i * 0.7f, 0, 0);
            SpriteRenderer sr = digitObj.GetComponent<SpriteRenderer>();
            sr.sprite = digitSprites[digitValue];
            currentDigits[i] = digitObj;
        }
    }
}
