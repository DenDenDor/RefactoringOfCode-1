using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pause : MonoBehaviour
{
    private static List<IStopped> _listOfIStoppable = new List<IStopped>();
    private static bool _isPressedEscape = false;
    public Action<bool> OnChangeActive;
    private void Update() 
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PressEscape();
        }
    }
    public void PressEscape()
    {
            _isPressedEscape =! _isPressedEscape;
            _listOfIStoppable.ForEach(e=>TryStoppingGame(e));
            OnChangeActive?.Invoke(_isPressedEscape);
    }
    private static void TryStoppingGame(IStopped entitie)
    {
        Action OnAciton = _isPressedEscape ? entitie.StopEntitie : entitie.PlayEntitie;
        OnAciton?.Invoke();
    }
    public static void AddEntitie(IStopped iStoppable)
    {
        _listOfIStoppable.Add(iStoppable);
        TryStoppingGame(iStoppable);
        
    }
    public static void RemoveEntitie(IStopped iStoppable)
    {
       _listOfIStoppable.Remove(iStoppable);
    }
}
