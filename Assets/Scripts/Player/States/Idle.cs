using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Player
{
    public class Idle : BaseState
    {
        private float verticalInput;

        public Idle(DriverSM stateMachine) : base("Idle", stateMachine) { }

        public override void Enter()
        {
            base.Enter();

            verticalInput = 0f;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            verticalInput = Input.GetAxis("Vertical");
            bool keyPreesed = Mathf.Abs(verticalInput) > Mathf.Epsilon;

            if (keyPreesed)
            {
                ChangeToDriverState();
            }
        }

        private void ChangeToDriverState()
        {
            DriverSM driverStateMachine = (DriverSM)stateMachine;

            stateMachine.ChangeState(driverStateMachine.driverState);
        }
    }
}
