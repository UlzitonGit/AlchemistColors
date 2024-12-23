using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeWindSpeed : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("speed", Random.Range(0.3f, 0.6f));
    }

   
}
