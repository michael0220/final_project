using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class moneygenerator : MonoBehaviour
{

    public Button btn;
    public float generateIntegral = 5f;
    public int generateEnergy = 10;
    public int unlockCost = 200;
    public TextMeshProUGUI unlockText;
    public TextMeshProUGUI upgradeGenerator;


    public bool isunlock = false;
    private float timer = 0f;
    void Start()
    {
        btn.onClick.AddListener(Unlock);
    }
    void Update()
    {
        if (isunlock)
        {
            timer += Time.deltaTime;
            if (timer >= generateIntegral)
            {
                timer = 0f;
                currency_manage.Instance.AddEnergy(generateEnergy);
            }
        }
    }
    void Unlock()
    {
        if (!isunlock && currency_manage.Instance.EnergyValue >= unlockCost)
        {
            currency_manage.Instance.SubEnergy(unlockCost);
            isunlock = true;
            unlockText.text = "+"+generateEnergy+"E/"+generateIntegral+"s";
            upgradeGenerator.text = "Starcore Link";
        }
    }
}
