using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;    // Prefab của pipe
    [SerializeField] private int poolSize = 5;         // Kích thước pool
    [SerializeField] private Transform parentObject;   // Object cha để chứa các pipe

    private List<GameObject> pipePool;                 // Danh sách các pipe trong pool

    void Start()
    {
        pipePool = new List<GameObject>();
        
        // Tạo và đặt các pipe làm con của parentObject
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab, parentObject);
            pipe.SetActive(false);              // Tắt ban đầu
            pipePool.Add(pipe);
        }
    }

    public GameObject GetPooledPipe()
    {
        for (int i = 0; i < pipePool.Count; i++)
        {
            if (!pipePool[i].activeInHierarchy)
            {
                return pipePool[i];
            }
        }

        // Nếu pool đầy, tạo pipe mới và đặt làm con của parentObject
        GameObject newPipe = Instantiate(pipePrefab, parentObject);
        newPipe.SetActive(false);
        pipePool.Add(newPipe);
        return newPipe;
    }

    public void ReturnPipeToPool(GameObject pipe)
    {
        pipe.SetActive(false);
    }
}