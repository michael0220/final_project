using UnityEngine;
using TMPro;
public class CloseHeroMenu : MonoBehaviour
{
    public CanvasGroup page1, page2;
    public TextMeshProUGUI menuOption;
    bool isClick;
    void Start()
    {
        SetCanvasGroup(page1, true);
        SetCanvasGroup(page2, false);
        isClick = false;
        menuOption.text = "Close";
    }
    public void ShowPage1()
    {
        SetCanvasGroup(page1, true);
        SetCanvasGroup(page2, false);
    }
    public void ShowPage2()
    {
        SetCanvasGroup(page1, false);
        SetCanvasGroup(page2, true);
    }
    public void CloseMenu()
    {
        if (!isClick)
        {
            SetCanvasGroup(page1, false);
            SetCanvasGroup(page2, false);
            isClick = true;
            menuOption.text = "Open";
        }
        else
        {
            ShowPage1();
            isClick = false;
            menuOption.text = "Close";
        }
    }

    void SetCanvasGroup(CanvasGroup group, bool visible)
    {
        group.alpha = visible ? 1 : 0;
        group.blocksRaycasts = visible;
        group.interactable = visible;
    }

    
}
