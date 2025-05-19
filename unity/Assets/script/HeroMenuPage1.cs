using UnityEngine;
using UnityEngine.UI;
public class HeroMenuPage1 : MonoBehaviour
{
    public Button page2Btn;
    public GameObject page1, page2;
    void Start()
    {
        page2Btn.onClick.AddListener(changePage);
    }

    void changePage()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }    
}
