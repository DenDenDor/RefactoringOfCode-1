using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DecreaserTime : IStopped
{
  private float _coolDown;
    private bool _isTimeGoing;
  private readonly float _minimumTimeForResetCooldown;
  private Action OnEndTime;
  public float CoolDown { get => _coolDown;  set => _coolDown = value; }
    public void DecreaseTime()
  {
     if(_isTimeGoing)
    {
    if (_coolDown == 0)
    {
        return;
    }
    if (_coolDown > 0)
    {
        _coolDown-=Time.deltaTime;
    }
    if (_coolDown <= _minimumTimeForResetCooldown)
    {
        OnEndTime?.Invoke();
    }
    }
  }
    public void StopEntitie()
    {
        _isTimeGoing = false;
    }
    public void PlayEntitie()
    {
        _isTimeGoing = true;
    }
  public DecreaserTime(float minimumTimeForResetCooldown, Action action)
  {
    _minimumTimeForResetCooldown = minimumTimeForResetCooldown;
    OnEndTime = action;
    SubscribeToPause();
  }
  private void SubscribeToPause() => Pause.AddEntitie(this);
  public DecreaserTime(float minimumTimeForResetCooldown)
  {
    _minimumTimeForResetCooldown = minimumTimeForResetCooldown;
    SubscribeToPause();
  }
}
