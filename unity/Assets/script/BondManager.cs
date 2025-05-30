using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class BondManager : MonoBehaviour
{
    public TextMeshProUGUI bondText;
    private float checkTimer = 0f;
    public float checkInterval = 1f;
    private string lastMessage = "";

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
        // 找出所有角色
        Hero_Melee_base[] heroes = FindObjectsByType<Hero_Melee_base>(FindObjectsSortMode.None);
        Hero_Ranged_base[] rangers = FindObjectsByType<Hero_Ranged_base>(FindObjectsSortMode.None);
        Hero_Tank_base[] tanks = FindObjectsByType<Hero_Tank_base>(FindObjectsSortMode.None);


        // 計算各角色是否存在
        bool hasHero1 = false;
        bool hasHero2 = false;
        bool hasHero3 = false;
        int tankCount = tanks.Length;

        foreach (var h in heroes)
        {
            if (h.heroType == HeroType.hero1)
                hasHero1 = true;
        }

        foreach (var r in rangers)
        {
            if (r.heroType == HeroType.hero2)
                hasHero2 = true;
            if (r.heroType == HeroType.hero3)
                hasHero3 = true;
        }

        bool heroBondActive = hasHero1 && hasHero2 && hasHero3;
        bool tankBondActive = tankCount >= 2;

        string message = "";

        // 英雄羈絆處理
        foreach (var h in heroes)
        {
            if (heroBondActive && h.heroType == HeroType.hero1)
                h.SetBondedDamageMultiplier(1.5f);
            else
                h.SetBondedDamageMultiplier(1f);
        }

        foreach (var r in rangers)
        {
            if (heroBondActive && (r.heroType == HeroType.hero2 || r.heroType == HeroType.hero3))
                r.SetBondedAttackSpeedMultiplier(2f);
            else
                r.SetBondedAttackSpeedMultiplier(1f);
        }

        // 坦克羈絆處理
        foreach (var t in tanks)
        {
            if (tankBondActive)
                t.SetBondedHpMultiplier(2f);
            else
                t.SetBondedHpMultiplier(1f);
        }

        if (heroBondActive)
            message += "Hero Bond Activated:Hero1 ATK x1.5,\nHero2&3 ATK SPD x2\n";

        if (tankBondActive)
            message += "Tank Bond Activated: Tank HP x2";

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
            bondText.text = "";
    }
}



 