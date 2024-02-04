using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBoxColliderSize : StateMachineBehaviour
{
    public GameObject gameObject;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject dragonGameObject = animator.gameObject;
        BoxCollider m_Collider = dragonGameObject.GetComponent<BoxCollider>();
        m_Collider.size = new Vector3(m_Collider.size[0], m_Collider.size[1], m_Collider.size[2] * 2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject dragonGameObject = animator.gameObject; 
        BoxCollider m_Collider = dragonGameObject.GetComponent<BoxCollider>();
        m_Collider.size = new Vector3(m_Collider.size[0], m_Collider.size[1], m_Collider.size[2]/2);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
