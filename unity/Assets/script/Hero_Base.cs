using System;
using UnityEngine;

public abstract class Hero_Base : MonoBehaviour
{
    public float maxHp;
    public float currHp;
    public bool isdead = false;

    private Transform attachPoint;
    private UFOcontroller currentUFO;
    private bool isAttach = false;

    public virtual void UpdateHp()
    {
        if (currHp >= maxHp) currHp = maxHp;
        if (currHp <= 0 && !isdead)
        {
            currHp = 0;
            Dead();
            if (isAttach && currentUFO != null)
            {
                currentUFO.DetachUFO();
            }
        }
    }

    public virtual void AttachToUFO(Transform point, UFOcontroller UFO)
    {
        isAttach = true;
        attachPoint = point;
        currentUFO = UFO;
        transform.position = point.position;
        transform.SetParent(point, worldPositionStays: true);
    }

    protected abstract void Dead();
}