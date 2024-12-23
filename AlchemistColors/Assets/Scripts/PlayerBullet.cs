using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] Vector3 dir;
    public string targetColor;
    public string color;
    [SerializeField] BulletsTypes[] bullets;
    [SerializeField] Transform spp;
    // Start is called before the first frame update
    void Start()
    {
        BulletsTypes bullet = null;
        for (int i = 0; i < bullets.Length; i++)
        {
            if(bullets[i].color == targetColor)
            {
                bullet = bullets[i];
            }
        }
        color = bullet.color;
        Instantiate(bullet.Particle, spp);
        Instantiate(bullet.Circle, spp);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Enemy"))
        {
            dir = dir * 0;
            
            StartCoroutine(Destroy());
        }
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
