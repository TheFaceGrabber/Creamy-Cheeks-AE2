using System.Collections;
using System.Collections.Generic;
using CreamyCheaks.AI;
using CreamyCheaks.AI.Decisions;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/SecondsPassed Decision")]
public class TenSecondsPassedDecision : Decision
{
	public float Time = 10;
	
	public override bool Run(FiniteStateMachine stateMachine)
	{
		if (stateMachine.InStateForSeconds > Time)
			return true;

		return false;
	}
}
