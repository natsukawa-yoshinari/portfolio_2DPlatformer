
using UnityEngine;

public class MoveState : IState
{
    private readonly Player _player;

    public MoveState(Player player)
    {
        _player = player;
    }

    public void OnStateEnter()
    {
        _player.Sr.color = Color.softYellow;
    }

    public void OnStateExit() { }

    public void OnUpdate()
    {
        if (_player.IsJumpPressed && _player.IsGrounded)
        {
            _player.StateMachine.ChangeState(_player.StateMachine.Jump);
            return;
        }

        if (_player.MoveInput != 0f && _player.IsDash)
        {
            _player.StateMachine.ChangeState(_player.StateMachine.Dash);
        }

        if (_player.MoveInput == 0f)
        {
            _player.StateMachine.ChangeState(_player.StateMachine.Idle);
        }
    }

    public void OnFixedUpdate()
    {
        Vector2 velocity = _player.Rb.linearVelocity;
        velocity.x = _player.MoveInput * _player.MoveSpeed;
        _player.Rb.linearVelocity = velocity;
    }
}
