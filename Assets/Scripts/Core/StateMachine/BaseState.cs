using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.StateMachine
{
    public class BaseState
    {
        public string name;
        protected StateMachine stateMachine;

        public BaseState(string name, StateMachine stateMachine)
        {
            this.name = name;
            this.stateMachine = stateMachine;
        }

        public virtual void Enter() { }

        public virtual void UpdateLogic() { }

        public virtual void UpdatePhysics() { }

        public virtual void Exit() { }

        public virtual void OnCollisionEnter2DStateMachine(Collision2D collision) { }

        public virtual void OnTriggerEnter2DStateMachine(Collider2D colider) { }
    }
}
