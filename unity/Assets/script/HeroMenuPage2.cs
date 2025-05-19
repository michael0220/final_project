using UnityEngine;
using UnityEngine.UI;
public class HeroMenuPage2 : MonoBehaviour
{
    public Button page1Btn;
    public GameObject page1, page2;
    void Start()
    {
        page1Btn.onClick.AddListener(changePage);
    }

    void changePage()
    {
        page2.SetActive(false);
        page1.SetActive(true);
    }    
}
