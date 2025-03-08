using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeDespawner : MonoBehaviour
{
    [SerializeField] private float despawnX = -10f; // Vị trí X để despawn pipe
    private Pipe pipe;

    void Start()
    {
        pipe = GetComponent<Pipe>();
    }

    void Update()
    {
        // Kiểm tra nếu pipe ra khỏi màn hình thì despawn
        if (transform.position.x < despawnX)
        {
            SimplePool.Despawn(pipe);
        }
    }
}
