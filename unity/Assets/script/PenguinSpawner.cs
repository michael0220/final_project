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
        Vector3 spawnPosition = new Vector3(-6, -2, 0); // �i�ۦ�վ��m
        Instantiate(penguinPrefab, spawnPosition, Quaternion.identity);
    }
}
