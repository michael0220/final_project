using UnityEngine;
using UnityEngine.UI;

public class levelmanager : MonoBehaviour
{
    public int levelindex;
    public GameObject unlocked;
    public GameObject locked;

    void Start()
    {
        FileIOManager.LoadProgressFromFile();
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 2);
        bool isUnlocked = levelindex <= unlockedLevel;
        unlocked.SetActive(isUnlocked);
        locked.SetActive(!isUnlocked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
