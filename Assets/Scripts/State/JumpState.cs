
using UnityEngine;

public class JumpState : IState
{
    private readonly Player _player;

    public JumpState(Player player)
    {
        _player = player;
    }

    public void OnStateEnter()
    {
        Vector2 velocity = _player.Rb.linearVelocity;
        velocity.y = _player.JumpPower;
        _player.Rb.linearVelocity = velocity;
        _player.Sr.color = Color.softGreen;
    }

    public void OnStateExit() { }

    public void OnUpdate()
    {
        // 接地していて、下降中または垂直速度が0なら着地扱い
        if (_player.IsGrounded && _player.Rb.linearVelocity.y <= 0f)
        {
            if (_player.MoveInput != 0f)
            {
                _player.StateMachine.ChangeState(_player.StateMachine.Move);
            }
            if (_player.MoveInput == 0f)
            {
                _player.StateMachine.ChangeState(_player.StateMachine.Idle);
            }
        }
    }

    public void OnFixedUpdate()
    {
        Vector2 velocity = _player.Rb.linearVelocity;
        velocity.x = _player.MoveInput * _player.MoveSpeed;
        if (_player.IsDash) velocity.x = _player.MoveInput * _player.MoveSpeed * 2;
        _player.Rb.linearVelocity = velocity;
    }
}
