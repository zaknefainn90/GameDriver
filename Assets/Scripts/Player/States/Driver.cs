using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Driver : BaseState
    {
        private float horizontalInput;
        private float verticalInput;

        public Driver(DriverSM stateMachine) : base("Driver", stateMachine) { }

        public override void Enter()
        {
            base.Enter();
            horizontalInput = 0f;
            verticalInput = 0f;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            DriverSM driverStateMachine = (DriverSM)stateMachine;
            horizontalInput = Input.GetAxis("Horizontal") * driverStateMachine.steerSpeed * Time.deltaTime;
            verticalInput = Input.GetAxis("Vertical") * driverStateMachine.basicMoveSpeed * Time.deltaTime;

            if (Mathf.Abs(verticalInput) > Mathf.Epsilon)
            {
                driverStateMachine.transform.Translate(0, verticalInput, 0);

                if (Mathf.Abs(horizontalInput) > Mathf.Epsilon)
                {
                    driverStateMachine.transform.Rotate(0, 0, -horizontalInput);
                }
            }
            else
            {
                stateMachine.ChangeState(driverStateMachine.idleState);
            }
        }
    }
}
