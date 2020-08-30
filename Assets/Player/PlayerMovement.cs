using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController _Controller;
    private PlayerInput _Input;
    private float _FallVelocity;
    public bool CanMove { get; set; }

    [SerializeField] private float _Gravity = 9.8f;
    [SerializeField] private float _Speed = 10.0f;

    private void Start()
    {
        _Controller = GetComponent<CharacterController>();
        _Input = GetComponent<PlayerInput>();
        CanMove = true;
    }

    private void Update()
    {
        if (CanMove)
        {
            Vector3 Velocity = new Vector3(0.0f, 0.0f, _Input.Vertical);
            Velocity = Vector3.ClampMagnitude(Velocity, 1) * _Speed;

            if (_Controller.isGrounded)
            {
                _FallVelocity = 0.0f;
            }
            else
            {
                _FallVelocity -= _Gravity;
            }

            //We add gravity force later in order not to be affected by player speed
            Velocity.y = _FallVelocity;

            _Controller.Move(Velocity * Time.deltaTime);
        }
    }
}
