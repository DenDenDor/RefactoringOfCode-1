using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static T GetRandomElementOfList<T>(this List<T> list)
    {
        return list[Random.Range(0,list.Count)];
    }
}
