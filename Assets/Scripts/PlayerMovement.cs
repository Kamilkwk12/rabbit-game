using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public ComputerUI computerUI;

    [SerializeField] private float moveSpeed = 1.5f;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.linearVelocity = _moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {

        _moveInput = context.ReadValue<Vector2>();

        if (_moveInput == Vector2.zero) {
            _animator.Play("Idle");
        }
        if (_moveInput == Vector2.up) {
            _animator.Play("WalkBack");
        }
        if (_moveInput == Vector2.down) {
            _animator.Play("WalkFront");
        }
        if (_moveInput == Vector2.left) {
            _animator.Play("WalkLeft");
        }
        if (_moveInput == Vector2.right) {
            _animator.Play("WalkRight");
        }
    }
}
