using System.Collections.Generic;
using UnityEngine;

public class StaticInteractable : MonoBehaviour, IInteractable
{
    public Animator animator;
    [HideInInspector] public string selectedParameter;

    private float currentValue = 0f;
    private float targetValue = 0f;
    private bool Interacting;
    private bool Activate;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Activate = false;
    }

    private void Update()
    {
        if (Interacting)
        {
            //Sets the float to the given value slowly
            currentValue = Mathf.MoveTowards(currentValue, targetValue, Time.deltaTime);
            animator.SetFloat(selectedParameter, currentValue);

            if (currentValue == targetValue)
                Interacting = false;
        }
    }

    //If the door is opening the door closes on this interact and the other way around
    public void Interact()
    {
        if (Activate)
        {
            targetValue = 1f;
            Activate = false;
        }
        else
        {
            targetValue = 0f;
            Activate = true;
        }

        Interacting = true;
    }
}
