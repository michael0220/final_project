using UnityEngine;

public class PenguinSpawner : MonoBehaviour
{
    public GameObject penguinPrefab;

    void Start()
    {
        SpawnPenguin();
    }

    void SpawnPenguin()
    {
        Vector3 spawnPosition = new Vector3(-6, -2, 0); // 可自行調整位置
        Instantiate(penguinPrefab, spawnPosition, Quaternion.identity);
    }
}
