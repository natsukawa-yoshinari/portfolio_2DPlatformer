
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _jumpPower = 8f;

    [SerializeField]
    private float _rayDist = 0.1f;
    [SerializeField]
    private Vector2 _playerOffset;
    [SerializeField]
    private TextMeshProUGUI _stateText;

    public Rigidbody2D Rb { get; private set; }
    public StateMachine StateMachine { get; private set; }

    public float MoveSpeed => _moveSpeed;
    public float JumpPower => _jumpPower;

    public float MoveInput { get; private set; }
    public bool IsJumpPressed { get; private set; }
    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        StateMachine = new StateMachine(this);
        StateMachine.Initialize(StateMachine.Idle);
    }

    private void Update()
    {
        MoveInput = 0f;
        IsJumpPressed = false;

        if (Keyboard.current.dKey.isPressed)
            MoveInput += 1f;

        if (Keyboard.current.aKey.isPressed)
            MoveInput -= 1f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            IsJumpPressed = true;
        }

        StateMachine.OnUpdate();

        _stateText.text = $"Current : {StateMachine.CurrentState}\nIsGround : {IsGrounded}";
    }

    private void FixedUpdate()
    {
        // 接地判定
        Vector2 origin = (Vector2)this.gameObject.transform.position + _playerOffset;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, _rayDist);
        if (hit.collider != null)
        {
            IsGrounded = true;
        }
        else IsGrounded = false;

        StateMachine.OnFixedUpdate();
    }

}
