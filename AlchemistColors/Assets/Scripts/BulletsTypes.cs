using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "BulletsSO", menuName = "New Bullet")]

public class BulletsTypes : ScriptableObject
{
    [field: SerializeField] public string color { get; private set; }
    [field: SerializeField] public GameObject Circle { get; private set; }
    [field: SerializeField] public GameObject Particle { get; private set; }

    public enum TypeThings
    {
        Color,
        Rune,
        Particle,
    }
}
