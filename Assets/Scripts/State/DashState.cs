
using UnityEngine;

public class DashState : IState
{
    private readonly Player _player;

    public DashState(Player player)
    {
        _player = player;
    }

    public void OnStateEnter()
    {
        _player.Sr.color = Color.softRed;
    }

    public void OnStateExit() { }

    public void OnUpdate()
    {
        if (_player.IsJumpPressed && _player.IsGrounded)
        {
            _player.StateMachine.ChangeState(_player.StateMachine.Jump);
            return;
        }

        if (_player.IsDash == false || _player.MoveInput == 0f)
        {
            _player.StateMachine.ChangeState(_player.StateMachine.Move);
        }
    }

    public void OnFixedUpdate()
    {
        Vector2 velocity = _player.Rb.linearVelocity;
        velocity.x = _player.MoveInput * _player.MoveSpeed * 2;
        _player.Rb.linearVelocity = velocity;
    }
}
