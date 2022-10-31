using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : Bullet
{
    [SerializeField] private GameObject _hitPrefab;
	[SerializeField] private LayerMask _layerMask;
	[SerializeField] private int _damage;
    [SerializeField] private ProjectileMovement _projectileMove;
    private void OnCollisionEnter(Collision co)
	{
		Debug.Log("Bam");
		_projectileMove.Speed = 0;

		ContactPoint contact = co.contacts[0];
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;

		if (_hitPrefab != null)
		{
			var hitVFX = Instantiate(_hitPrefab, pos, rot);
			var psHit = hitVFX.GetComponent<ParticleSystem>();
			if (psHit != null)
				Destroy(hitVFX, psHit.main.duration);
			else
			{
				var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
				Destroy(hitVFX, psChild.main.duration);
			}
		}

		if ((_layerMask.value & 1 << co.gameObject.layer) == 1 << co.gameObject.layer) {
			Debug.Log("I have Found the enemy");
			co.gameObject.GetComponent<BasicHealthSystem>().ApplyDamage(_damage);
		}

		Destroy(gameObject);
	}

}
