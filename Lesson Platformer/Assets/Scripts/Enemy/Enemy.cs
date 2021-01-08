using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private int _damage;

    private SpriteRenderer _spriteRenderer;
    private int _directionX = -1;

    private void OnEnable()
    {
        _groundChecker.GroundIsNotFound += FlipDirection;
    }

    private void OnDisable()
    {
        _groundChecker.GroundIsNotFound -= FlipDirection;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 direction = new Vector3(_directionX, 0, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void FlipDirection()
    {
        _directionX *= -1;
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            player.ApplyDamage(_damage);
    }
}
