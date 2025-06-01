using Unity.VisualScripting;
using UnityEditor.Analytics;
using UnityEngine;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;

public class Hero_Tank_base : Hero_Base, IDamageable
{

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

        maxHp += (level - 1) * 50;
        currHp = maxHp;

        upgradeLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHp();
        hp_bar.transform.localScale = new Vector3((float)(currHp / maxHp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    public void takeDamage(float amount)
    {
        if (RandomEventManager.isTankVeryStrong)
        {
            currHp -= amount * 0.5f;
        }
        else currHp -= amount*0.8f;
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
