using UnityEngine;
using System.Collections.Generic;

public class healerSkill : Hero_Base
{
    [SerializeField] private float addHp;
    [SerializeField] private float healInterval;
    private Dictionary<Hero_Base, float> healTimers = new Dictionary<Hero_Base, float>();

    void Start()
    {
        currHp = maxHp;
    }

    void Update()
    {
        UpdateHp();
        List<Hero_Base> keys = new List<Hero_Base>(healTimers.Keys);
        foreach (var hero in keys)
        {
            if (hero == null || hero.isdead)
            {
                healTimers.Remove(hero);
                continue;
            }

            healTimers[hero] += Time.deltaTime;

            if (healTimers[hero] >= healInterval)
            {
                hero.currHp += addHp;
                if (hero.currHp > hero.maxHp) hero.currHp = hero.maxHp;
                healTimers[hero] = 0f;
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("hero")) return;

        Hero_Base hero = collision.GetComponent<Hero_Base>();
        if (hero != null && !healTimers.ContainsKey(hero))
        {
            healTimers.Add(hero, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("hero")) return;

        Hero_Base hero = collision.GetComponent<Hero_Base>();
        if (hero != null && healTimers.ContainsKey(hero))
        {
            healTimers.Remove(hero);
        }
    }

    protected override void Dead()
    {
        isdead = true;
    }
}
