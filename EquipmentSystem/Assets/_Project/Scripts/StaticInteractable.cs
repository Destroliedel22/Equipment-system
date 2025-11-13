using UnityEngine;

public class StaticInteractable : MonoBehaviour, IInteractable
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if(animator != null)
        {
            if (animator.GetBool("Activate"))
                animator.SetBool("Activate", false);
            else
                animator.SetBool("Activate", true);
        }
    }
}
