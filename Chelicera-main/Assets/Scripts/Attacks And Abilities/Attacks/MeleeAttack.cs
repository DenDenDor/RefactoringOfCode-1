using System.Linq;
using Assets.Scripts.Attacks_And_Abilities.Attacks;
using UnityEngine;

public class MeleeAttack : Ability
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private ParticleSystem _patyicleSyatem;

    [SerializeField] private Vector3 _areaOfEffectSize;
    [SerializeField] private LayerMask _enemyLayer;
    private float _additionalValueOfArea = 2;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            return;
        }
        DecreaserTime.DecreaseTime();
    }
    private void Attack()
    {
        if (DecreaserTime.CoolDown != 0)
        {
            return;
        }
        _patyicleSyatem.Play();
        DecreaserTime.CoolDown = _maxCoolDownTime;
        Collider[] _hitEnemies = Physics.OverlapBox(transform.position, _areaOfEffectSize / _additionalValueOfArea, transform.rotation, _enemyLayer);
        _hitEnemies.ToList().ForEach(e=>e.GetComponent<BasicHealthSystem>().ApplyDamage(_damage));
    }

    private void OnDrawGizmosSelected()
    {
        if (transform == null)
            return;
        Gizmos.DrawWireCube(transform.position, _areaOfEffectSize);
    }
}
