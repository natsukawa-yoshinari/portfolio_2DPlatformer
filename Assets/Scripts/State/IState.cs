using UnityEngine;

public interface IState
{
    void OnStateEnter();
    void OnStateExit();
    void OnUpdate();
    void OnFixedUpdate();
}
