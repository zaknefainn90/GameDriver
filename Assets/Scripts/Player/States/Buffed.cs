using System.Collections;
using UnityEngine;
using Core.StateMachine;
using GameUI;

namespace Player
{
    public class Buffed : BaseState
    {
        public Buffed(DriverSM stateMachine) : base("Buffed", stateMachine) { }

        private SpeedUI _speedUI;
        private DriverSM _driverStateMachine;
        private Movment _movment;
        private float _timerCurrent;
        private float _tempBasicMoveSpeed;

        public override void Enter()
        {
            base.Enter();

            _driverStateMachine = (DriverSM)stateMachine;
            _tempBasicMoveSpeed = _driverStateMachine.basicMoveSpeed;
            _timerCurrent = _driverStateMachine.buffsTimerDuration;
            _movment = new Movment(_driverStateMachine.gameObject);
            _speedUI = GameObject.FindObjectOfType<SpeedUI>();

            UseBuff();
        }

        private void UseBuff()
        {
            _driverStateMachine.basicMoveSpeed = _driverStateMachine.triggeredBuffComponent.CalcCurrentMovment(_driverStateMachine.basicMoveSpeed);
            _driverStateMachine.triggeredBuffComponent.DestroyBuff();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            MovePlayer();
            IntervalBuffTimer();
        }

        private void MovePlayer()
        {
            _movment.UpdatePositionsByAxis(_driverStateMachine.steerSpeed, _driverStateMachine.basicMoveSpeed);
            _movment.ManageMovment();
        }

        private void IntervalBuffTimer()
        {
            if (_timerCurrent > 0)
            {
                _timerCurrent -= Time.deltaTime;
            }
            else
            {
                ResetBuffTimer();
            }
        }

        private void ResetBuffTimer()
        {
            _timerCurrent = _driverStateMachine.buffsTimerDuration;
            _driverStateMachine.basicMoveSpeed = _tempBasicMoveSpeed;
            _speedUI.Speed = 100;
            stateMachine.ChangeState(_driverStateMachine.idleState);
        }
    }
}