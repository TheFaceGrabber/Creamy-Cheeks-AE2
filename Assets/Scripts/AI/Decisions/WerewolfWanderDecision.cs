using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreamyCheaks.AI.Decisions
{
    [CreateAssetMenu(menuName = "AI/Decisions/Werewolf Wander Decision")]
    public class WerewolfWanderDecision : Decision
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

            if (werewolf.CurrentTarget == null || werewolf.CurrentTarget.GetComponent<rpgStats>().Health.GetValue() <= 0)
                return true;

            if (stateMachine.DistanceLeft <= stateMachine.Agent.stoppingDistance)
            {
                var dir = werewolf.CurrentTarget.transform.position - werewolf.transform.position;
                if (!Physics.Raycast(werewolf.transform.position, dir, werewolf.TargetScanDistance + 1,
                    werewolf.FollowLayerMask))
                {
                    werewolf.CurrentTarget = null;
                    return true;
                }
            }

            return false;
        }
    }
}
