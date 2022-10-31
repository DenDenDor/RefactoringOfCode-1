using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorBulletParticle : MonoBehaviour
{
    [SerializeField] private float _fireRate;
	[SerializeField] private ParticleSystem _muzzlePrefab;
    public float FireRate { get => _fireRate; private set => _fireRate = value; }
    private void Start()
	{
		if (_muzzlePrefab != null)
		{
			var muzzleVFX = Instantiate(_muzzlePrefab, transform.position, Quaternion.identity);
			muzzleVFX.transform.forward = transform.forward;
			float duration = muzzleVFX != null ?muzzleVFX.main.duration : muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>().main.duration;
			Destroy(muzzleVFX.gameObject,duration);
		}
	}
}
