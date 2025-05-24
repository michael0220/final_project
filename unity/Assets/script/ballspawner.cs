using UnityEngine;

public class ballspawner : MonoBehaviour
{
    public GameObject BallPrefab;

    public void Spawnball()
    {
        Instantiate(BallPrefab, transform.position, Quaternion.identity);
    }
}
