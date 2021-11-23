using Core;
using Core.StateMachine;
using Player;
using UnityEngine;

public class DriverSM : StateMachine
{
    [Header("Movment")]
    [SerializeField] public float steerSpeed = 100f;
    [SerializeField] public float basicMoveSpeed = 20f;
    [Header("Buffs")]
    [SerializeField] public float buffsTimerDuration = 3;

    [HideInInspector]
    public Idle idleState;
    [HideInInspector]
    public Driver driverState;
    [HideInInspector]
    public Buffed buffedState;
    [HideInInspector]
    public Buffs triggeredBuffComponent;

    private void Awake()
    {
        idleState = new Idle(this);
        driverState = new Driver(this);
        buffedState = new Buffed(this);
    }

    protected override BaseState GetInitialState()
    {
        return (BaseState)idleState;
    }
}
