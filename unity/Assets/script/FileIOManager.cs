using UnityEngine;
using System.IO;

public static class FileIOManager
{
    private static string filepath => Application.persistentDataPath + "/progress.txt";

    public static void SaveProgressToFile()
    {
        int unlockedbuildindex = PlayerPrefs.GetInt("UnlockedLevel", 2);
        int displayindex = unlockedbuildindex - 1;
        string content = $"Unlocked Level: {displayindex}";
        File.WriteAllText(filepath, content);
        Debug.Log("儲存檔案路徑: " + Application.persistentDataPath);
    }

    public static void LoadProgressFromFile()
    {
        Debug.Log("儲存檔案路徑: " + Application.persistentDataPath);
        if (!File.Exists(filepath))
        {
            return;
        }
        string content = File.ReadAllText(filepath).Trim().ToLower();
        if (string.IsNullOrEmpty(content) || content == "clear")
        {
            PlayerPrefs.SetInt("UnlockedLevel", 2);
            PlayerPrefs.Save();
            return;
        }
        if (content.StartsWith("unlocked level:"))
        {
            string numberpart = content.Replace("unlocked level:", "").Trim();
            if (int.TryParse(numberpart, out int unlockedLevel))
            {
                int buildindex = unlockedLevel + 1;
                PlayerPrefs.SetInt("UnlockedLevel", buildindex);
                PlayerPrefs.Save();
                return;
            }
        }
    }
    
}