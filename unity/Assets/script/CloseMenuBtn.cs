using UnityEngine;
using UnityEngine.UI;
public class CloseMenuBtn : MonoBehaviour
{
    public Button closeBtn;
    public CanvasGroup menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeBtn.onClick.AddListener(closeMenu);
        SetCanvasGroup(menu, false);
    }

    // Update is called once per frame
    void closeMenu()
    {
        SoundEffectManager.Instance.PressBuyHero();
        SetCanvasGroup(menu, false);
    }
    void SetCanvasGroup(CanvasGroup group, bool visible)
    {
        group.alpha = visible ? 1 : 0;
        group.blocksRaycasts = visible;
        group.interactable = visible;
    }
}
