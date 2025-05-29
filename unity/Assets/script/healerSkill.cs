using UnityEngine;
using System.Collections.Generic;

public class healerSkill : MonoBehaviour
{
    [SerializeField] private float addHp;

    private Dictionary<Hero_Melee_base, float> meleeHp = new Dictionary<Hero_Melee_base, float>();
    private Dictionary<Hero_Ranged_base, float> rangedHp = new Dictionary<Hero_Ranged_base, float>();
    private Dictionary<Hero_Tank_base, float> tankHp = new Dictionary<Hero_Tank_base, float>();

    void OnTriggerStay2D(Collider2D collision)
    {
        
    }
}
