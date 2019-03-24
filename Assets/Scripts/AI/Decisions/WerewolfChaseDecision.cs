using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreamyCheaks.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/Werewolf Chase Decision")]
    public class WerewolfChaseDecision : Decision
    {
        public override bool Run(FiniteStateMachine stateMachine)
        {
            if (stateMachine == null)
            {
                return false;
            }

            WerewolfFSM werewolf = stateMachine.GetComponent<WerewolfFSM>();
            if (werewolf == null)
                return false;

            return werewolf.CurrentTarget != null && Vector3.Distance(werewolf.CurrentTarget.transform.position,werewolf.transform.position) > werewolf.AttackDistance;
        }
    }
}
