using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject redSquarePrefab;
    public GameObject blackSquarePrefab;
    public float spawnInterval = 1.2f;
    public float minX = -3f;
    public float maxX = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnBlock();
            timer = 0f;
        }
    }

    void SpawnBlock()
    {
        float x = Random.Range(minX, maxX);
        Vector3 spawnPos = new Vector3(x, transform.position.y, 0f);

        // Random xem rơi block đỏ hay đen
        bool spawnRed = Random.value > 0.5f;
        GameObject prefab = spawnRed ? redSquarePrefab : blackSquarePrefab;

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}