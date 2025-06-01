using UnityEngine;
using System.Collections.Generic;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance { get; private set; }

    public int upgradeCost = 50;
    public int maxlevel = 3;

    private Dictionary<HeroType, int> herolevels = new Dictionary<HeroType, int>();

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;

            foreach (HeroType type in System.Enum.GetValues(typeof(HeroType)))
            {
                herolevels[type] = 1;
            }
        }
        else Destroy(gameObject);
    }

    public int Getlevel(HeroType type) {
        if (herolevels.ContainsKey(type)) return herolevels[type];
        return 1;
    }

    public bool Upgrade(HeroType type) {
        int currentLevel = Getlevel(type);

        if (currentLevel >= maxlevel) return false;

        if (currency_manage.Instance.EnergyValue < upgradeCost) return false;

        currency_manage.Instance.SubEnergy(upgradeCost);
        herolevels[type]++;
        return true;
    }
}   
