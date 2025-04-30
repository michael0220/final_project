using UnityEngine;

public class FadePanelController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("FadeIn"); // ���� FadeIn �ʵe
    }

    public void PlayFadeOut()
    {
        animator.Play("FadeOut"); // ���� FadeOut �ʵe�]�A�n�����o�Ӱʵe�^
    }
}
