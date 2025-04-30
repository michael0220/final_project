using UnityEngine;

public class FadePanelController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("FadeIn"); // 播放 FadeIn 動畫
    }

    public void PlayFadeOut()
    {
        animator.Play("FadeOut"); // 播放 FadeOut 動畫（你要先做這個動畫）
    }
}
