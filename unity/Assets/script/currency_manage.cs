using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Image imageOFcurrency;
    private Vector3 imagePos;
    public float produceTime ;
    private float prodouceTimer;
    public GameObject EnPrefab;

    private void Awake(){
        Instance = this;
    }
    private void Start() {
        UpdateEnergytext();
        CalPosition();
    }

    private void Update(){
        ProduceEn();
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

    public Vector3 GetPosition(){
        return imagePos;
    }

    private void CalPosition(){
        Vector3 position = Camera.main.ScreenToWorldPoint(imageOFcurrency.transform.position);
        position.z = 0;
        imagePos = position;
    }

    void ProduceEn(){
        prodouceTimer += Time.deltaTime;
        if(prodouceTimer>produceTime){
            prodouceTimer = 0;
            Vector3 position = new Vector3(Random.Range(-6,5.5f),6.1f,0);
            GameObject go = GameObject.Instantiate(EnPrefab,position,Quaternion.identity);

            position.y = Random.Range(-3.8f, 1.2f);
            go.GetComponent<Energy>().LinearTo(position);
        }
    }
} 
