using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraReflection : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reflect());
    }

    IEnumerator Reflect()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
    }
}
   

