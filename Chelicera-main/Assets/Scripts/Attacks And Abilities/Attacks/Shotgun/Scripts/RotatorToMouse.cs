using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorToMouse 
{
	private readonly Camera _camera;
	private readonly Transform _currentPoint;
	private readonly float _maximumLenght = 5;
	private readonly float _time = 1;
	private Vector3 _direction;
	private Quaternion _rotation;
    public Quaternion Rotation { get => _rotation; private set => _rotation = value; }
    public void TryRotatingCamera() 
	{
		if (_camera != null) 
		{
			RaycastHit hit;
			var mousePos = Input.mousePosition;
			Ray rayMouse = _camera.ScreenPointToRay (mousePos);
			Vector3 position = Physics.Raycast (rayMouse.origin, rayMouse.direction, out hit, _maximumLenght) ? hit.point : rayMouse.GetPoint (_maximumLenght);
			RotateToMouseDirection(position);
		}
	}

	private void RotateToMouseDirection(Vector3 destination)
	{
		_direction = destination - _currentPoint.transform.position;
		Rotation = Quaternion.LookRotation (_direction);
		_currentPoint.localRotation = Quaternion.Lerp (_currentPoint.transform.rotation, Rotation, _time);
	}
	public RotatorToMouse(Transform currentPoint, Camera camera)
	{
		_currentPoint = currentPoint;
		_camera = camera;
	}

}
