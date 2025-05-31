using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    public HeroType heroType;
    private Button btn;
    public TextMeshProUGUI levelText;


    private void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(() =>
        {
            UpgradeManager.Instance.Upgrade(heroType);
        });
    }
    void Update() {
        int level = UpgradeManager.Instance.Getlevel(heroType);
        levelText.text = "Lv. " + level.ToString();
    }
}