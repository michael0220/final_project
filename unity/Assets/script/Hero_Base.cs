using System;
using UnityEngine;

public abstract class Hero_Base : MonoBehaviour
{
    public float maxHp;
    public float currHp;
    public bool isdead = false;

    public virtual void UpdateHp()
    {
        if (currHp >= maxHp) currHp = maxHp;
        if (currHp <= 0 && !isdead)
        {
            currHp = 0;
            Dead();
        }
    }

    protected abstract void Dead();
}