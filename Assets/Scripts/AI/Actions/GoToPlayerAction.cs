using System.Collections;
using System.Collections.Generic;
using CreamyCheaks.AI;
using CreamyCheaks.AI.Actions;
using UnityEngine;


[CreateAssetMenu(menuName = "AI/Actions/GoToPlayer Action")]
public class GoToPlayerAction : Action {
    public override void Run(FiniteStateMachine stateMachine)
    {
        var node = GameObject.FindWithTag("Player");

        stateMachine.Agent.SetDestination(node.transform.position);

        stateMachine.enabled = true;
        stateMachine.Agent.isStopped = false;

        if (stateMachine.GetComponent<WerewolfFSM>())
        {
            stateMachine.Animator.SetBool("IsRunning", false);
            stateMachine.Animator.SetBool("IsWalking", true);
            stateMachine.Agent.speed = 1.5f;
        }
        else
        {
            stateMachine.Animator.SetBool("IsWalking", true);
        }

        Vector3 loc = new Vector3(stateMachine.Agent.steeringTarget.x, stateMachine.transform.position.y,
            stateMachine.Agent.steeringTarget.z);
        var dir = loc - stateMachine.transform.position;
        stateMachine.WantedRotation =
            dir == Vector3.zero ? stateMachine.transform.rotation : Quaternion.LookRotation(dir);

        stateMachine.HeadLookTarget = Vector3.zero;

        stateMachine.Agent.stoppingDistance = 1.5f;

        RaycastHit hit;
        if (Physics.Raycast(stateMachine.transform.position, stateMachine.transform.forward, out hit, 1))
        {
            Door door = hit.collider.GetComponent<Door>();
            if (door != null)
            {
                door.PlayerInteract();
            }
        }
    }
}
