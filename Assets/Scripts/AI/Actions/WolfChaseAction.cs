using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreamyCheaks.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Wolf Chase Action")]
    public class WolfChaseAction : Action
    {
        public override void Run(FiniteStateMachine stateMachine)
        {
            if (stateMachine == null)
            {
                return;
            }
            
            WerewolfFSM werewolf = stateMachine.GetComponent<WerewolfFSM>();
            if (werewolf == null)
                return;
            
            Vector3 loc = new Vector3(stateMachine.Agent.steeringTarget.x, stateMachine.transform.position.y,
                stateMachine.Agent.steeringTarget.z);
            var dir = loc - stateMachine.transform.position;
            stateMachine.WantedRotation =
                dir == Vector3.zero ? stateMachine.transform.rotation : Quaternion.LookRotation(dir);

            stateMachine.HeadLookTarget = Vector3.zero;

            stateMachine.Agent.stoppingDistance = 1f;
            stateMachine.Animator.SetBool("IsWalking", false);
            stateMachine.Animator.SetBool("IsRunning", true);
            stateMachine.Agent.speed = 2.5f;
            //if (stateMachine.DistanceLeft <= stateMachine.Agent.stoppingDistance)
            //{
            stateMachine.Agent.SetDestination(werewolf.LastKnowTargetPos);
            //}
            
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
}
