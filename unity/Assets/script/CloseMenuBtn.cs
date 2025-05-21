using UnityEngine;
using UnityEngine.UI;
public class CloseMenuBtn : MonoBehaviour
{
    public Button closeBtn;
    public GameObject menu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closeBtn.onClick.AddListener(closeMenu);
    }

    // Update is called once per frame
    void closeMenu()
    {
        menu.SetActive(false);
    }
}
