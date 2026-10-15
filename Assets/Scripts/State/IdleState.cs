using UnityEditor;
using UnityEngine;

public class IdleState : IState
{
    private readonly Player _player;

    public IdleState(Player player)
    {
        _player = player;
    }

    public void OnStateEnter() { }

    public void OnStateExit() { }

    public void OnUpdate()
    {
        if (_player.IsJumpPressed && _player.IsGrounded)
        {
            _player.StateMachine.ChangeState(_player.StateMachine.Jump);
            return;
        }

        if (_player.MoveInput != 0f)
        {
            _player.StateMachine.ChangeState(_player.StateMachine.Move);
        }
    }

    public void OnFixedUpdate()
    {
        Vector2 velocity = _player.Rb.linearVelocity;
        velocity.x = 0f;
        _player.Rb.linearVelocity = velocity;
    }
}
