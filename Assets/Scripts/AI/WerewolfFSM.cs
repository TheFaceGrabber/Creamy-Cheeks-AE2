using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreamyCheaks.AI
{
    public class WerewolfFSM : FiniteStateMachine
    {
        public float AttackDistance = 2;

        public float TargetScanDistance = 15;
        public float ScanRate = 0.5f;
        public LayerMask ScanMask;
        public LayerMask FollowLayerMask;

        public WerewolfTarget CurrentTarget { get; set; }
        public Vector3 LastKnowTargetPos { get; private set; }

        private float lastScanTime;

        public void Awake()
        {
            base.Awake();
        }

        // Use this for initialization
        public void Start()
        {
            base.Start();
        }

        public void Damage()
        {
            //TODO Damage Player - change damage value?
            if(CurrentTarget)
                CurrentTarget.SendMessage("TakeDamage",-1);
        }

        // Update is called once per frame
        public void Update()
        {
            base.Update();
            ScanForTargets();
            FollowTarget();
        }

        void FollowTarget()
        {
            if (CurrentTarget == null) return;

            RaycastHit hit;
            var dir = CurrentTarget.transform.position - transform.position;
            if (Physics.Raycast(transform.position, dir, TargetScanDistance + 1, FollowLayerMask))
            {
                Debug.DrawRay(transform.position, dir);
                LastKnowTargetPos = CurrentTarget.transform.position;
            }
        }

        void ScanForTargets()
        {
            if (CurrentTarget)
            {
                if(CurrentTarget.GetComponent<rpgStats>().Health.GetValue() <= 0 || !CurrentTarget.isActiveAndEnabled)
                    CurrentTarget = null;
                else
                    return;
            }

            if (Time.time > lastScanTime + ScanRate)
            {
                Collider[] colls = Physics.OverlapSphere(transform.position, TargetScanDistance, ScanMask);
                for (int i = 0; i < colls.Length; i++)
                {
                    WerewolfTarget target = colls[i].GetComponent<WerewolfTarget>();
                    if (target)
                    {
                        if (target.GetComponent<rpgStats>().Health.GetValue() <= 0) continue;

                        CurrentTarget = target;
                        break;
                    }
                }

                lastScanTime = Time.time;
            }
        }
    }
}