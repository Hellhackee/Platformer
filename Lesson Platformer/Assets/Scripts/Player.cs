using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _health;

    public UnityAction Die;
    public UnityAction<int> HealthChanged;

    private float _currentSpeed = 0;
    private float _previousSpeed = 0;
    private bool _isGrounded = true;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
        HealthChanged?.Invoke(_health);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            _currentSpeed = _speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
            _currentSpeed = _speed;
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _currentSpeed = 0;
        }
        
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && _isGrounded)
        {
            _currentSpeed = 0;
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }

        if (_previousSpeed != _currentSpeed)
        {
            _animator.SetFloat("Speed", _currentSpeed);
            _previousSpeed = _currentSpeed;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isGrounded)
            if (collision.gameObject.GetComponent<Tilemap>())
                _isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Tilemap>())
            _isGrounded = false;
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        
        if (_health <= 0)
            Die?.Invoke();
    }
}
