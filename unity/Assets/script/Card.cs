using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

enum state{
    cooling,
    waitingEnergy,
    ready
}
public class Card : MonoBehaviour
{
    private state cardstate = state.cooling;
    
    public GameObject Lightmode;
    public GameObject Darkmode;
    public Image Maskmode;

    [SerializeField]
    private float cdtime = 2;
    private float cdtimer = 0;

    [SerializeField]
    private int needEnergy = 50;

    private void Start() {
        transtoready();
    }
    private void Update()
    {
        switch (cardstate)
        {
            case state.cooling:
                coolingUpdate();
                break;
            case state.waitingEnergy:
                waitingEnergyUpdate();
                break;
            case state.ready:
                readyUpdate();
                break;
        }
    }

    void coolingUpdate(){
        cdtimer += Time.deltaTime;

        Maskmode.fillAmount = (cdtime-cdtimer)/cdtime;

        if(cdtimer >= cdtime){
            transtowaitingE();
        }
    }
    void waitingEnergyUpdate(){
        if(needEnergy <= currency_manage.Instance.EnergyValue){
            transtoready();
        }
    }
    void readyUpdate(){
        if(needEnergy > currency_manage.Instance.EnergyValue){
            transtowaitingE();
        }
    }
    void transtowaitingE(){
        cardstate = state.waitingEnergy;

        Lightmode.SetActive(false);
        Darkmode.SetActive(true);
        Maskmode.gameObject.SetActive(false);
    }
    void transtoready(){
        cardstate = state.ready;

        Lightmode.SetActive(true);
        Darkmode.SetActive(false);
        Maskmode.gameObject.SetActive(false);
    }
    void transtocooling(){
        cardstate = state.cooling;
        cdtimer = 0;

        Lightmode.SetActive(false);
        Darkmode.SetActive(true);
        Maskmode.gameObject.SetActive(true);
    }
    public void OnClick()
    {
        if (needEnergy > currency_manage.Instance.EnergyValue) return;

        currency_manage.Instance.SubEnergy(needEnergy);

        transtocooling();
    }
}
