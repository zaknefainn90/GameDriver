using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Core.StateMachine;

public class DriverSM : StateMachine
{
    [Header("Movment")]
    [SerializeField] public float steerSpeed = 100f;
    [SerializeField] public float basicMoveSpeed = 20f;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Driver driverState;

    private void Awake()
    {
        idleState = new Idle(this);
        driverState = new Driver(this);
    }

    protected override BaseState GetInitialState()
    {
        return (BaseState)idleState;
    }
}
