using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public int point = 25;

    public void OnMouseDown(){
        currency_manage.Instance.AddEnergy(point);
    }
}
