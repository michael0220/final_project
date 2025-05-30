using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;

public class Hero_Tank_base : Hero_Base, IDamageable
{
    private float hpBondMultiplier = 1f;
    private float baseMaxHp; // ➤ 記錄初始 maxHp（不含羈絆加成）

    public void SetBondedHpMultiplier(float multiplier)
    {
        if (hpBondMultiplier != multiplier)
        {
            hpBondMultiplier = multiplier;
            float newMaxHp = baseMaxHp * hpBondMultiplier;

            // 不改變實際血量，只調整 maxHp
            float oldRatio = currHp / maxHp; // 原本畫面上的血條比例
            maxHp = newMaxHp;
            currHp = maxHp * oldRatio; // 用血條比例維持畫面一致
        }
    }

    public HeroType heroType;
    public GameObject hp_bar;
    Collider2D heroCollider;
    Rigidbody2D rb;
    Animator anim;
    public TextMeshProUGUI levelText;

    void Start()
    {
        heroCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        int level = UpgradeManager.Instance.Getlevel(heroType);

        // 🛠️ 正確初始化 base maxHp + 等級加成（例如 300 為坦克厚度）
        baseMaxHp = 100 + (level - 1) * 50 + 300;

        maxHp = baseMaxHp; // 預設未加成的 maxHp
        currHp = maxHp;

        upgradeLevelText();
    }

    void Update()
    {
        UpdateHp();
        hp_bar.transform.localScale = new Vector3((float)(currHp / maxHp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }

    public void takeDamage(float amount)
    {
        currHp -= amount;
    }

    protected override void Dead()
    {
        isdead = true;
        rb.simulated = false;
        heroCollider.enabled = false;
        anim.SetTrigger("dead");
    }

    public void Onhero_deadAnimationEnd()
    {
        Destroy(gameObject);
    }

    void upgradeLevelText()
    {
        int level = UpgradeManager.Instance.Getlevel(heroType);
        levelText.text = level.ToString();
    }
}

