using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftClick : StateMachineBehaviour
{
    private Animator animator;

    // Use OnStateEnter instead of Start
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get the Animator component attached to the GameObject
        this.animator = animator;

        // Ensure an Animator component is present
        if (this.animator == null)
        {
            Debug.LogError("Animator component not found on the GameObject.");
        }
    }

    // Use OnStateUpdate instead of Update
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Trigger the animation
            TriggerAnimation();
        }
    }

    void TriggerAnimation()
    {
        // Check if the Animator component is not null
        if (animator != null)
        {
            // Trigger the animation named "YourAnimationName"
            animator.SetTrigger("YourAnimationName");
        }
        else
        {
            Debug.LogError("Animator component is null. Make sure it is attached to the GameObject.");
        }
    }
}