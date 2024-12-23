using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] float offset;
    [SerializeField] PlayerBullet[] bullet;
    [SerializeField] ColorMixer colorMixer;
    [SerializeField] Animator animator;
    bool canShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        if (Input.GetKey(KeyCode.Mouse0) && canShoot)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        StartCoroutine(Reload());
        animator.SetTrigger("Shoot");
        for (int i = 0; i < bullet.Length; i++)
        {
            if(bullet[i].color == colorMixer.currentColor)
            {
                Instantiate(bullet[i].gameObject, transform.position, transform.rotation);
            }
        }
    }
    IEnumerator Reload()
    {
        canShoot = false;
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}
