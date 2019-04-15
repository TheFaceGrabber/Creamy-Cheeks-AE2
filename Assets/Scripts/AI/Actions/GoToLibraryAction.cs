using System.Collections;
using System.Collections.Generic;
using CreamyCheaks.AI;
using CreamyCheaks.AI.Actions;
using UnityEngine;

namespace CreamyCheaks.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/GoToLibraryAction")]
    public class GoToLibraryAction : Action
    {
        public override void Run(FiniteStateMachine stateMachine)
        {
            //TODO FORMULA
            
            var gunObj = GameObject.Find("Formula Object");
            if (gunObj)
            {
                stateMachine.ItemHeldForPlayer = gunObj.GetComponent<GunWorldItem>();
                gunObj.GetComponent<Collider>().enabled = false;
            }
            //if gunObj is null, it means the player already has the gun
			
            //Copy these two lines
            stateMachine.enabled = true;
            stateMachine.Agent.isStopped = false;

            var node = GameObject.Find("FindFormulaNode");
            stateMachine.Agent.SetDestination(node.transform.position);
			
            //Keep all below here
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

            stateMachine.Agent.stoppingDistance = 1f;
			
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