using UnityEngine;
using UnityEngine.UI;

public class ButtonImageChanger : MonoBehaviour
{
    public Button targetButton;       
    public Sprite newSprite;             

    private Image buttonImage;
    private bool isChanged = false;

    void Start()
    {
        buttonImage = targetButton.GetComponent<Image>();
        targetButton.onClick.AddListener(ChangeImageOnce);
    }
    void ChangeImageOnce()
    {
        if (!isChanged)
        {
            buttonImage.sprite = newSprite;
            isChanged = true;
        }
    }
}
