using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ScoreAdd.Instance.AddScore(1); // Truy cập qua Singleton
            AudioManager.instance.Play("point");
        }
    }
}
