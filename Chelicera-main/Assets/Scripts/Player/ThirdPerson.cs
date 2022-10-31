using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
   [SerializeField] private CharacterController _characterController;
   private IMovable _iMovable;
   private void Awake() 
   {
     _iMovable = new ThirdPersonMovement(transform, _characterController);
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
