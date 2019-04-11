using System.Collections;
using System.Collections.Generic;
using CreamyCheaks.AI;
using CreamyCheaks.AI.Decisions;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/HasReachedDestination Decision")]
public class HasReachedDestinationDecision : Decision 
{
    public override bool Run(FiniteStateMachine stateMachine)
    {
        return stateMachine.DistanceLeft <= stateMachine.Agent.stoppingDistance;
    }
}
