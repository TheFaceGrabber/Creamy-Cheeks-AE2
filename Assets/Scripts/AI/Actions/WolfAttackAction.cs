using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreamyCheaks.AI.Actions
{
    [CreateAssetMenu(menuName = "AI/Actions/Wolf Attack Action")]
    public class WolfAttackAction : Action
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
           
            werewolf.Animator.ResetTrigger("Attack");
            werewolf.Animator.SetTrigger("Attack");
            //TODO Attack logic
        }
    }
}
