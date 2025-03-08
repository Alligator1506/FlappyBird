using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnParent;     // Parent để tổ chức các pipe trong hierarchy
    [SerializeField] private PipeData pipeData;         // ScriptableObject chứa dữ liệu pipe
    
    private PipeType _pipeType;                         // Loại pipe hiện tại
    
    [SerializeField] private float spawnRate = 1.5f;    // Thời gian giữa các lần spawn
    [SerializeField] private float heightOffset = 5f;   // Phạm vi ngẫu nhiên cho chiều cao
    [SerializeField] private float spawnXPosition = 10f;// Vị trí X spawn pipe
    [SerializeField] private float despawnXPosition = -10f; // Vị trí X để despawn pipe

    private float spawnTimer = 0f;
    private List<Pipe> pipes = new List<Pipe>();        // Danh sách các pipe đang hoạt động

    void Start()
    {
        // Khởi tạo với pipe đầu tiên
        _pipeType = PipeType.Pipe1; // Có thể chọn ngẫu nhiên nếu muốn
        SpawnPipe(_pipeType);
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            // Chọn ngẫu nhiên một PipeType từ PipeData
            _pipeType = pipeData.PipeItems[Random.Range(0, pipeData.PipeItems.Count)].type;
            SpawnPipe(_pipeType);
            spawnTimer = 0f;
        }

        // Kiểm tra và despawn các pipe ra khỏi màn hình
        CheckAndDespawnPipes();
    }

    public void SpawnPipe(PipeType pipeType)
    {
        this._pipeType = pipeType;

        // Tạo vị trí spawn với chiều cao ngẫu nhiên
        float randomHeight = Random.Range(-1, 4);
        Vector3 spawnPosition = new Vector3(spawnXPosition, randomHeight, 0);

        // Spawn pipe mới mà không despawn pipe cũ
        Pipe newPipe = SimplePool.Spawn<Pipe>((PoolType)pipeType, spawnPosition, Quaternion.identity, spawnParent);
        pipes.Add(newPipe); // Thêm vào danh sách quản lý
    }

    private void CheckAndDespawnPipes()
    {
        // Duyệt qua danh sách từ cuối về đầu để tránh lỗi khi xóa
        for (int i = pipes.Count - 1; i >= 0; i--)
        {
            Pipe pipe = pipes[i];
            if (pipe.transform.position.x < despawnXPosition)
            {
                SimplePool.Despawn(pipe);
                pipes.RemoveAt(i);
            }
        }
    }

    // Reset tất cả pipe khi cần (ví dụ: khi restart game)
    public void ResetPipes()
    {
        while (pipes.Count > 0)
        {
            Pipe pipe = pipes[0];
            if (pipe != null)
            {
                SimplePool.Despawn(pipe);
            }
            pipes.RemoveAt(0);
        }

        // Spawn pipe đầu tiên để bắt đầu lại
        spawnTimer = 0f;
        _pipeType = PipeType.Pipe1;
        SpawnPipe(_pipeType);
    }

    // Để debug trong Editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(new Vector3(spawnXPosition, 0, 0), new Vector3(1f, heightOffset * 2, 1f));
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(despawnXPosition, 0, 0), new Vector3(1f, heightOffset * 2, 1f));
    }
}
