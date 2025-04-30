using UnityEngine;

public class FadeController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // 抓到同一個物件上的 Animator
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeInTrigger"); // 設定動畫參數，播放動畫
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOutTrigger");
    }
}
