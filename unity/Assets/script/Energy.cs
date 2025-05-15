using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;

public class Energy : MonoBehaviour
{
    public float MoveD = 1;
    public int point = 25;
    public static int Ecount;

    void OnEnable(){
        Ecount++;
    }

    void OnDestroy(){
        Ecount--;
    }
    
    public void LinearTo(Vector3 targetPos){
        transform.DOMove(targetPos, MoveD);
    }
    public void OnClicked(){
        Debug.Log("要移動到的位置：" + currency_manage.Instance.GetPosition());

        transform.DOMove(currency_manage.Instance.GetPosition(), MoveD)
        .SetEase(Ease.OutQuad)
        .OnComplete(
            () =>
            {
                Destroy(this.gameObject);
                currency_manage.Instance.AddEnergy(point);
            }
        );
    }
}
