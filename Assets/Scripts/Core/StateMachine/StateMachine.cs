using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.StateMachine
{
    public class StateMachine : MonoBehaviour
    {
        public BaseState currentState;

        void Start()
        {
            currentState = GetInitialState();

            if (currentState != null)
            {
                currentState.Enter();
            }
        }

        void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateLogic();
            }
        }

        void LateUpdate()
        {
            if (currentState != null)
            {
                currentState.UpdatePhysics();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (currentState != null)
            {
                currentState.OnCollisionEnter2DStateMachine(collision);
            }
        }

        private void OnTriggerEnter2D(Collider2D colider)
        {
            if (currentState != null)
            {
                currentState.OnTriggerEnter2DStateMachine(colider);
            }
        }

        public void ChangeState(BaseState newState)
        {
            currentState.Exit();
            currentState = newState;
            currentState.Enter();
        }

        protected virtual BaseState GetInitialState()
        {
            return null;
        }

        //private void OnGUI()
        //{
        //    string content = currentState != null ? currentState.name : "(no current state)";
        //    GUILayout.Label($"<color='white'><size=40>{content}</size></color>");
        //}
    }
}
