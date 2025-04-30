using UnityEngine;

public class FadeController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>(); // ���P�@�Ӫ���W�� Animator
    }

    public void FadeIn()
    {
        animator.SetTrigger("FadeInTrigger"); // �]�w�ʵe�ѼơA����ʵe
    }

    public void FadeOut()
    {
        animator.SetTrigger("FadeOutTrigger");
    }
}
