using System.Collections.Generic;
using Assets.Scripts.Attacks_And_Abilities.Attacks;
using UnityEngine;
using System;
public class Shotgun : Ability
{
    [SerializeField] private List<Bullet> _bullets;
    [SerializeField] private int _damagePerBullet;
    [SerializeField] private int _numberOfBullets;
    private void Update()
    {
        DecreaserTime.DecreaseTime();
        if (Input.GetButtonDown("Fire2")) 
        {
            Shoot();
        }
    }
    private void Shoot() 
    {
        if (DecreaserTime.CoolDown > 0) 
        {
            return;
        }
        if (_bullets.Count == 0) 
        {
            throw new IndexOutOfRangeException();
        }
        DecreaserTime.CoolDown = _maxCoolDownTime;
        for (int i = 0; i < _numberOfBullets; i++) 
        {
            Bullet bullet = _bullets.GetRandomElementOfList();
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
