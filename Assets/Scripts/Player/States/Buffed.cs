using System.Collections;
using UnityEngine;
using Core.StateMachine;

namespace Player
{
    public class Buffed : BaseState
    {
        public Buffed(DriverSM stateMachine) : base("Buffed", stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Buffed State");
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
        }
    }
}