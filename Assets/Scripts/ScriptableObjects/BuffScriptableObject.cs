using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffScriptableObject", menuName = "ScriptableObject/BuffScriptableObject", order = 1)]
public class BuffScriptableObject : ScriptableObject
{
    public float boostValue = 5;
    public BuffsType type;
}