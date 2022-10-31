using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : IMovable
{
    private float _speed = 4;
	private Transform _currentTransform;
	private bool _isTimeGoing;
    public float Speed { get => _speed; set => _speed = value; }
	public void Move()
	{
        if (Speed != 0 && _isTimeGoing)
		{
			_currentTransform.position += _currentTransform.forward * (Speed * Time.deltaTime);
		}
	}
	public void StopEntitie()
    {
        _isTimeGoing = false;
    }
    public void PlayEntitie()
    {
        _isTimeGoing = true;
    }
	public ProjectileMovement(Transform transform)
	{
		Pause.AddEntitie(this);
		_currentTransform = transform;
	}
}