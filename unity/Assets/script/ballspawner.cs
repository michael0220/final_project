using UnityEngine;

public class ballspawner : MonoBehaviour
{
    [SerializeField] private GameObject BallPrefab;

    public void Spawnball()
    {
        Instantiate(BallPrefab, transform.position, Quaternion.identity);
    }
}
