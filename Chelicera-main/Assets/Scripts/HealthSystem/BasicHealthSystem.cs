using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BasicHealthSystem : MonoBehaviour
{
    [SerializeField] private int _health = 0;
    [SerializeField] private int _maxHealth = 0;
    private bool _isAlife = true; 
    public int MaxHealth { get => _maxHealth; private set => _maxHealth = value;}
    public int Health { get => _health; private set => _health = value; }
    public event Action OnApplyDamage;
    public void ApplyDamage(int damage) 
    {
        if (damage <= 0)
        {
            throw new InvalidOperationException();
        }
        Health -= damage;
        OnApplyDamage?.Invoke();
        if (Health <= 0 && _isAlife)
        {
            Die();
        }
    }

    protected virtual void Die() 
    {
        _isAlife = false;
        Destroy(gameObject);
    }
}
