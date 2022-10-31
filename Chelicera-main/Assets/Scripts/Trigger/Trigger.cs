using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
    public void TriggerCollider<T>(Collider collider, Action action) where T : MonoBehaviour
    {
        if (collider.TryGetComponent<T>(out T other))
        {
            action?.Invoke();
        }
    }
}
