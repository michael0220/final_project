using UnityEngine;
using System.Collections.Generic;

public class healerSkill : Hero_Base
{
    [SerializeField] private float addHp;
    [SerializeField] private float healInterval;
    Hero_Base heroScript;
    public GameObject hp_bar;
    Collider2D heroCollider;
    Rigidbody2D rb;
    public float timer;
    void Start()
    {
        currHp = maxHp;
        heroCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= healInterval && heroScript != null) Heal();
        hp_bar.transform.localScale = new Vector3((float)(currHp / maxHp), hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("hero"))
        {
            heroScript = collision.GetComponent<Hero_Base>();
        }
    }

    void Heal()
    {
        heroScript.currHp += addHp;
        timer = 0;
    }
}
