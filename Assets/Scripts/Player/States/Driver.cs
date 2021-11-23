using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.StateMachine;
using Core;

namespace Player
{
    public class Driver : BaseState
    {
        private DriverSM _driverStateMachine;
        private Movment _movment;

        public Driver(DriverSM stateMachine) : base("Driver", stateMachine) { }

        public override void Enter()
        {
            base.Enter();

            _driverStateMachine = (DriverSM)stateMachine;
            _movment = new Movment(_driverStateMachine.gameObject);
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            MovePlayer();
        }

        private void MovePlayer()
        {
            _movment.UpdatePositionsByAxis(_driverStateMachine.steerSpeed, _driverStateMachine.basicMoveSpeed);
            _movment.ManageMovment();

            if (!_movment._isVerticalKeysPressed)
            {
                NoAxisPressedGoToIdle();
            }
        }


        public override void OnTriggerEnter2DStateMachine(Collider2D colider)
        {
            base.OnTriggerEnter2DStateMachine(colider);

            if (colider.tag == "Buff")
            {
                _driverStateMachine.triggeredBuffComponent = colider.gameObject.GetComponent<Buffs>(); ;
                _driverStateMachine.ChangeState(_driverStateMachine.buffedState);
            }
        }

        private void NoAxisPressedGoToIdle()
        {
            stateMachine.ChangeState(_driverStateMachine.idleState);
        }
    }
}
