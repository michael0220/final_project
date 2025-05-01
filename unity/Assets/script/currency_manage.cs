using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class currency_manage : MonoBehaviour
{
    public static currency_manage Instance { get;private set;}
    [SerializeField]
    private int energyVal;
    public int EnergyValue
    {
        get {return energyVal;}
    }
    public TextMeshProUGUI textOFcurrency;

    private void Awake(){
        Instance = this;
    }
    private void Start() {
        UpdateEnergytext();
    }

    private void UpdateEnergytext(){
        textOFcurrency.text = EnergyValue.ToString();
    }

    public void SubEnergy(int point){
        energyVal-=point;
        UpdateEnergytext();
    }

    public void AddEnergy(int point){
        energyVal+=point;
        UpdateEnergytext();
    }
} 
