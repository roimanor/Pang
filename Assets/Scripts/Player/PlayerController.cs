using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerModel))]
public class PlayerController : MonoBehaviour
{
    private PlayerModel _playerModel;
    private Rigidbody2D rb;
    private Vector3 velocity;
    private float _lastShotTime = 0f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _playerModel = GetComponent<PlayerModel>();

    }

    private void Update()
    {
        rb.velocity = velocity;
    }

    public void Left(InputAction.CallbackContext context)
    {
        if (context.started)
            velocity = new Vector3(-_playerModel.PlayerVelocity, 0f, 0f);
        else if (context.canceled)
            velocity = Vector3.zero;
    }
    public void Right(InputAction.CallbackContext context)
    {
        if (context.started)
            velocity = new Vector3(_playerModel.PlayerVelocity, 0f, 0f);
        else if (context.canceled)
            velocity = Vector3.zero;
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (Time.time < _lastShotTime + _playerModel.ShootCD)
            return;
        if (context.started)
        {
            _lastShotTime = Time.time;
            Instantiate(_playerModel.ArrowPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bubble"))
            GameManager.Instance.EndGame();
    }
}
