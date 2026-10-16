
using TMPro;
using UniRx;
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
    public SpriteRenderer Sr { get; private set; }
    public StateMachine StateMachine { get; private set; }

    public float MoveSpeed => _moveSpeed;
    public float JumpPower => _jumpPower;
    private ReactiveProperty<float> _highestY = new(0f);
    public ReactiveProperty<float> HighestY => _highestY;
    private float _startY = 0f;

    public float MoveInput { get; private set; }
    public bool IsDash { get; private set; }
    public bool IsJumpPressed { get; private set; }
    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Sr = GetComponent<SpriteRenderer>();
        StateMachine = new StateMachine(this);
        StateMachine.Initialize(StateMachine.Idle);
        _startY = this.gameObject.transform.position.y;
    }

    private void Update()
    {
        MoveInput = 0f;
        IsJumpPressed = false;

        CheckHighest();

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            float y = GetY();
            _highestY.Value = y;
        }

        if (Keyboard.current.dKey.isPressed)
            MoveInput += 1f;

        if (Keyboard.current.aKey.isPressed)
            MoveInput -= 1f;

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            IsJumpPressed = true;
        }

        if (Keyboard.current.leftShiftKey.isPressed) IsDash = true;
        else IsDash = false;

        StateMachine.OnUpdate();

        _stateText.text = $"Current : {StateMachine.CurrentState}";
    }

    private void FixedUpdate()
    {
        // 接地判定
        Vector2 origin = (Vector2)this.gameObject.transform.position + _playerOffset;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, _rayDist);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.layer == 7)
                IsGrounded = true;
        }
        else IsGrounded = false;

        StateMachine.OnFixedUpdate();
    }

    private void CheckHighest()
    {
        float y = GetY();

        if (_highestY.Value < y)
        {
            _highestY.Value = y;
        }
    }

    private float GetY()
    {
        float y;
        if (_startY >= 0) y = this.gameObject.transform.position.y + _startY;
        else if (_startY < 0) y = this.gameObject.transform.position.y - _startY;
        else y = this.gameObject.transform.position.y;
        return y;
    }

}
