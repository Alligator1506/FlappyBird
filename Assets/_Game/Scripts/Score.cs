using UnityEngine;

public class Score : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && UIGamePlay.Instance != null)
        {
            UIGamePlay.Instance.AddScore(1);
            AudioManager.instance.Play("point");
        }
    }
}
