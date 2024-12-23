using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "EnemySO", menuName = "New Enemy")]

public class EnemyTypes : ScriptableObject
{
    [field: SerializeField] public string color { get; private set; }
    [field: SerializeField] public GameObject rune { get; private set; }
   

    public enum TypeThings
    {
        Color,
        Rune,
      
    }
}
