using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : IMovable
{
    private float _speed = 6f;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    private readonly CharacterController _controller;
    private readonly Transform _currentTransform;
    private readonly float _maxRange =0.1f;
    private bool _isTimeGoing;
    public float Speed { get => _speed; set => _speed = value; }
    public void StopEntitie()
    {
        _isTimeGoing = false;
    }
    public void PlayEntitie()
    {
        _isTimeGoing = true;
    }
    public void Move()
    {
        if(_isTimeGoing)
        {
         float horizontal = Input.GetAxisRaw("Horizontal");
         float vertical = Input.GetAxisRaw("Vertical");
         Vector3 direction = Camera.main.transform.right * horizontal + Camera.main.transform.forward * vertical;
         direction.y = 0;
         if (direction.magnitude >= _maxRange) 
         {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_currentTransform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            _currentTransform.rotation = Quaternion.Euler(0f, angle, 0f);
            _controller.Move(direction * Speed * Time.deltaTime);
         }
        }
    }
    public ThirdPersonMovement(Transform transform,CharacterController characterController)
    {
        Pause.AddEntitie(this);
        _currentTransform = transform;
        _controller = characterController;
    }
}
