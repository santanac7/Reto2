using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentFollowBehaviour : StateMachineBehaviour
{
    AgentMeleeMovement agent;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = FindObjectOfType<AgentMeleeMovement>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Follow();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.agent.speed = 5.0f;
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
    private void Follow()
    {

        if (agent.playerOnTarget)
        {
            agent.changeTarget = false;
            agent.agent.speed = 10.0f;
            agent.agent.SetDestination(agent.player.transform.position);
            //if (agent.playerOnTarget && agent.distanceWithPlayer <= 4f)
            //{
            //    agent._animator.SetTrigger("Attack");
            //}
        }
        else
        {
            agent.agent.SetDestination(agent.targetsPatrolling[0].position);
            agent.changeTarget=true;
        }

    }
}
