using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class moneygenerator : MonoBehaviour
{
    public Button btn;
    public Button UpgradeEffi;
    public CanvasGroup menu;
    public float generateIntegral = 5f;
    public int generateEnergy = 10;
    public int unlockCost = 200;
    public TextMeshProUGUI unlockText;
    public TextMeshProUGUI EffiLevel;
    public int upgradeCost = 100;
    private int currentLevel = 1;
    private int maxLevel = 10;


    public bool isunlock = false;
    private float timer = 0f;
    void Start()
    {
        btn.onClick.AddListener(Unlock);
        UpgradeEffi.onClick.AddListener(upgrade);
        SetCanvasGroup(menu, false);
    }
    void Update()
    {
        if (isunlock)
        {
            unlockText.text = "+" + (generateEnergy + (currentLevel-1)*20) + "E/" + generateIntegral + "s";
            timer += Time.deltaTime;
            if (timer >= generateIntegral)
            {
                timer = 0f;
                currency_manage.Instance.AddEnergy(generateEnergy + (currentLevel-1)*20);
            }
        }
        EffiLevel.text = "Spend " + upgradeCost + " E to upgrade Generate Efficientcy. Level " + currentLevel + "/10";
    }
    void Unlock()
    {
        if (!isunlock && currency_manage.Instance.EnergyValue >= unlockCost)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(energy_menu);
            currency_manage.Instance.SubEnergy(unlockCost);
            GetComponent<ButtonTooltip>().hidePanel();
            GetComponent<ButtonTooltip>().enabled = false;
            isunlock = true;
        }
    }
    void energy_menu()
    {
        if (isunlock)
        {
            SetCanvasGroup(menu, true);
        }
        else return;
    }
    void upgrade()
    {
        if (currency_manage.Instance.EnergyValue < upgradeCost) return;
        else
        {
            if (currentLevel < maxLevel)
            {
                currency_manage.Instance.SubEnergy(upgradeCost);
                currentLevel++;
            }
            else return;
        }
    }
    void SetCanvasGroup(CanvasGroup group, bool visible)
    {
        group.alpha = visible ? 1 : 0;
        group.blocksRaycasts = visible;
        group.interactable = visible;
    }
}
