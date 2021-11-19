using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.StateMachine;

namespace Player
{
    public class Driver : BaseState
    {
        private float horizontalInput;
        private float verticalInput;
        private DriverSM driverStateMachine;

        public Driver(DriverSM stateMachine) : base("Driver", stateMachine) { }

        public override void Enter()
        {
            base.Enter();

            driverStateMachine = (DriverSM)stateMachine;
            horizontalInput = 0f;
            verticalInput = 0f;
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            UpdatePositionsByAxis(driverStateMachine);
            ManageMovment();
        }

        //public override void OnCollisionEnter2DStateMachine(Collision2D collision)
        //{
        //    base.OnCollisionEnter2DStateMachine(collision);
        //}

        public override void OnTriggerEnter2DStateMachine(Collider2D colider)
        {
            base.OnTriggerEnter2DStateMachine(colider);

            if (colider.tag == "Buff")
            {
                Debug.Log("pickBuff");
            }
        }

        private void UpdatePositionsByAxis(DriverSM driverStateMachine)
        {
            horizontalInput = Input.GetAxis("Horizontal") * driverStateMachine.steerSpeed * Time.deltaTime;
            verticalInput = Input.GetAxis("Vertical") * driverStateMachine.basicMoveSpeed * Time.deltaTime;
        }

        private void ManageMovment()
        {
            bool verticalKeysPressed = Mathf.Abs(verticalInput) > Mathf.Epsilon;

            if (verticalKeysPressed)
            {
                MovePlayerByAxis();
            }
            else
            {
                NoAxisPressChangeToIdleState();
            }
        }

        private void NoAxisPressChangeToIdleState()
        {
            stateMachine.ChangeState(driverStateMachine.idleState);
        }

        private void MovePlayerByAxis()
        {
            driverStateMachine.transform.Translate(0, verticalInput, 0);
            bool horizontalKeysPressed = Mathf.Abs(horizontalInput) > Mathf.Epsilon;

            if (horizontalKeysPressed)
            {
                driverStateMachine.transform.Rotate(0, 0, -horizontalInput);
            }
        }
    }
}
