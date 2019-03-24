using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreamyCheaks.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/Werewolf Attack Decision")]
    public class WerewolfAttackDecision : Decision
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
            
            if (stateMachine.DistanceLeft <= werewolf.AttackDistance)
                return true;

            return false;
        }
    }
}
