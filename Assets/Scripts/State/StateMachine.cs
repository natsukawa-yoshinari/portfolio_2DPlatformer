
using System;
using UnityEngine;

public class StateMachine
{
    public IState CurrentState { get; private set; }

    public IdleState Idle { get; }
    public MoveState Move { get; }
    public JumpState Jump { get; }

    public StateMachine(Player player)
    {
        Idle = new IdleState(player);
        Move = new MoveState(player);
        Jump = new JumpState(player);
    }

    public void Initialize(IState firstState)
    {
        if (firstState == null) return;

        CurrentState = firstState;
        CurrentState.OnStateEnter();
    }

    public void ChangeState(IState nextState)
    {
        if (nextState == null) return;

        CurrentState.OnStateExit();
        CurrentState = nextState;
        CurrentState.OnStateEnter();
    }

    public void OnUpdate()
    {
        CurrentState?.OnUpdate();
    }

    public void OnFixedUpdate()
    {
        CurrentState?.OnFixedUpdate();
    }
}
