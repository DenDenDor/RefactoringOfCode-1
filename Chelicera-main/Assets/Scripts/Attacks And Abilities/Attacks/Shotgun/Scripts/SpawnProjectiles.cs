using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour 
{

	[SerializeField] private Transform _firePoint;
	[SerializeField] private List<Bullet> _listOfVFX = new List<Bullet> ();
	[SerializeField] private RotatorToMouse _rotateToMouse;
	[SerializeField] private Camera _camera;
	private Bullet _effectToSpawn;
	private float _timeToFire = 0;
	private readonly float _additionalTime = 1;
	private void Start () 
	{
		_effectToSpawn = _listOfVFX.FirstOrDefault();
		_rotateToMouse = new RotatorToMouse(transform,_camera);
	}
	private void Update () 
	{
		_rotateToMouse.TryRotatingCamera();
		if(Input.GetMouseButton (0) && Time.time >= _timeToFire)
		{
			_timeToFire = Time.time + _additionalTime / _effectToSpawn.CreatorBulletParticle.FireRate;
			SpawnVFX();
		}
	}

	private void SpawnVFX ()
	{
		if (_firePoint == null || _rotateToMouse == null)
		{
			throw new ArgumentNullException();
		}
		Bullet currentVFX = Instantiate (_effectToSpawn, _firePoint.transform.position, Quaternion.identity);
		currentVFX.transform.localRotation = _rotateToMouse.Rotation;
	}
}
