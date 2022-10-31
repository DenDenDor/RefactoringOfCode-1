using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable : IStopped
{
   public float Speed {get;set;}
   public void Move();
}
