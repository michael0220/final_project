using UnityEngine;
using TMPro; 

using UnityEngine.UI; 

public class BondManager : MonoBehaviour
{
    public TextMeshProUGUI bondText;  
    private float checkTimer = 0f;
    public float checkInterval = 1f;

    private string lastMessage = "";
    void Start()
{
    Debug.Log("BondText 連接狀態：" + (bondText != null ? "✅ 已連接" : "❌ 沒連接"));
}
    void Update()
    {
        checkTimer += Time.deltaTime;
        if (checkTimer >= checkInterval)
        {
            ApplyBonds();
            checkTimer = 0f;
        }
    }

    void ApplyBonds()
    {
        Hero[] heroes = Object.FindObjectsByType<Hero>(FindObjectsSortMode.None);
        hero2[] archers = Object.FindObjectsByType<hero2>(FindObjectsSortMode.None);


        int heroCount = heroes.Length;
        int archerCount = archers.Length;

        float heroHpMultiplier = 1.0f;
        float archerRateMultiplier = 1.0f;
        string message = "";

        if (heroCount > 2)
        {
            heroHpMultiplier = 1.5f;
            message = "Hero Bond Activated: HP x1.5\n";
        }

        if (archerCount > 2)
        {
            archerRateMultiplier = 1.5f;
            message = "Archer Bond Activated: Attack Speed x1.5\n";
        }

        if (heroCount > 3 && archerCount > 3)
        {
            heroHpMultiplier *= 2f;
            archerRateMultiplier *= 2f;
            message = "Bond Boost: Effects Doubled!";
        }

        foreach (Hero h in heroes)
        {
            h.max_hp = Mathf.RoundToInt(400 * heroHpMultiplier);
            h.hp = Mathf.RoundToInt(h.hp * heroHpMultiplier);
            if (h.hp > h.max_hp)
                h.hp = h.max_hp;
        }

        foreach (hero2 h2 in archers)
        {
            h2.delaytime = 1.0f / archerRateMultiplier;
        }

        if (message != lastMessage)
        {
            ShowBondText(message);
            lastMessage = message;
        }
    }

    void ShowBondText(string message)
    {
        if (bondText != null)
        {
            bondText.text = message;
            CancelInvoke(nameof(ClearText));
            Invoke(nameof(ClearText), 5f); // 顯示5秒
        }
    }

    void ClearText()
    {
        if (bondText != null)
        {
            bondText.text = "";
        }
    }
}

