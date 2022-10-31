using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private CreatorBulletParticle _creatorBulletParticle;
    private IMovable _iMovable;
    public CreatorBulletParticle CreatorBulletParticle { get => _creatorBulletParticle; private set => _creatorBulletParticle = value; }
    private void Awake() 
    {
      _iMovable = new ProjectileMovement(transform);   
    }
    private void Update() 
    {
        _iMovable.Move();
    }
    private void OnDisable() 
   {
    Pause.RemoveEntitie(_iMovable);
   }
}
