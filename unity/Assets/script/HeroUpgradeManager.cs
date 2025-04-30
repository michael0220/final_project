using UnityEngine;
using System.Collections.Generic;

public class HeroUpgradeManager : MonoBehaviour
{
    public static HeroUpgradeManager Instance;

    public int currentlevel = 1;
    public int maxlevel = 3;

    private List<Hero> activeHeroes = new List<Hero>();

    void Awake(){
        if(Instance==null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterHero(Hero hero){
        activeHeroes.Add(hero);
    }

    public void UpgradeAllHeroes(){
        if(currentlevel>=maxlevel) return;

        currentlevel++;
        foreach(Hero hero in activeHeroes){
            if(hero != null){
            }
        }
    }
}
