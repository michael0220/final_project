using System;
using Unity.Mathematics;
using UnityEngine;
using TMPro;
using System.Collections;

public class RandomEventManager : MonoBehaviour
{
    public int level;
    public GameObject panel;
    public TextMeshProUGUI eventText;
    public TextMeshProUGUI eventDetailText;
    public TextMeshProUGUI randomEventText;
    private CanvasGroup canvasGroup;
    public float fadeDuration;
    public float showDuration;
    public static bool isShowing=true;
    public static bool isEnemySpeedUp = false;
    public static bool isTankVeryStrong = false;
    public static bool isHeroVeryStrong = false;
    public static bool isHero2WithPowerfulBullet = false;
    public static bool isHero3Stronger = false;
    public static bool isMoreEnemy = false;
    public int BounsEnergy = 500;
    randomEvent eventType;
    void Start()
    {
        canvasGroup = panel.GetComponent<CanvasGroup>();
        ChooseRandomEvent();
    }
    public enum randomEvent
    {
        EnemySpeedUp, BonusGold, TankVeryStrong, MoreEnemy, HeroVeryStrong, Hero2WithPowerfulBullet, Hero3stronger
    }

    void ChooseRandomEvent()
    {
        isShowing = true;
        if (level == 1)
        {
            eventType = (randomEvent)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(randomEvent)).Length - 1);
        }
        else eventType = (randomEvent)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(randomEvent)).Length);

        switch (eventType)
        {
            case randomEvent.EnemySpeedUp:
                isEnemySpeedUp = true;
                eventText.text = "The enemies are on drugs!";
                eventDetailText.text = "Enemies move 1.5x faster than usual";
                randomEventText.text = "Random Event: " + eventDetailText.text;
                showPanel();
                break;
            case randomEvent.BonusGold:
                currency_manage.Instance.AddEnergy(BounsEnergy);
                eventText.text = "You found energy in space debris";
                eventDetailText.text = "+500 Energy Bonus!";
                randomEventText.text = "Random Event: " + eventDetailText.text;
                showPanel();
                break;
            case randomEvent.TankVeryStrong:
                isTankVeryStrong = true;
                eventText.text = "Tank stole Captain America's shield";
                eventDetailText.text = "Tank gains 20% damage reduction";
                randomEventText.text = "Random Event: " + eventDetailText.text;
                showPanel();
                break;
            case randomEvent.MoreEnemy:
                isMoreEnemy = true;
                eventText.text = "Enemies can now reproduce!";
                eventDetailText.text = "Prepare to face even more enemies";
                randomEventText.text = "Random Event: " + eventDetailText.text;
                showPanel();
                break;
            case randomEvent.HeroVeryStrong:
                isTankVeryStrong = true;
                eventText.text = "Hero got a girlfriend — now fights with stronger shoulders";
                eventDetailText.text = "Hero gains +20 damage and +50% HP";
                randomEventText.text = "Random Event: " + eventDetailText.text;
                showPanel();
                break;
            case randomEvent.Hero2WithPowerfulBullet:
                isHero2WithPowerfulBullet = true;
                eventText.text = "Hero2's bullets upgraded from wood to iron";
                eventDetailText.text = "Hero2's bullet damage +10";
                randomEventText.text = "Random Event: " + eventDetailText.text;
                showPanel();
                break;
            case randomEvent.Hero3stronger:
                isHero3Stronger = true;
                eventText.text = "Hero3 injected cholesterol boosters";
                eventDetailText.text = "Hero3 gains +50% HP and draws the bow 20% faster";
                randomEventText.text = "Random Event: " + eventDetailText.text;
                showPanel();
                break;
        }
    }

    public void showPanel()
    {
        StartCoroutine(showPanelEffect());
    }

    IEnumerator showPanelEffect()
    {
        panel.SetActive(true);
        canvasGroup.alpha = 0f;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = timer / fadeDuration;
            yield return null;
        }

        yield return new WaitForSeconds(showDuration);

        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = 1f - (timer / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0f;
        panel.SetActive(false);
        isShowing = false;
    }

}