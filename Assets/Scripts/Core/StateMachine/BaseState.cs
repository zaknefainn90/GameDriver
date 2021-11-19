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

        public static explicit operator BaseState(Idle v)
        {
            throw new NotImplementedException();
        }
    }

}
