using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    public HeroType heroType;
    private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(() =>
        {
            UpgradeManager.Instance.Upgrade(heroType);
        });
    }
}