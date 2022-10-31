using Assets.Scripts.Attacks_And_Abilities.Attacks;
using UnityEngine;

public class SpiderDamage : Ability
{

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private int _damage;

    void OnCollisionEnter(Collision co)
    {
        if ((_layerMask.value & 1 << co.gameObject.layer) == 1 << co.gameObject.layer)
        {
            co.gameObject.GetComponent<BasicHealthSystem>().ApplyDamage(_damage);
        }
    }
}
