using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManeger : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public float speed;
 
    void Start()
    {
       player = GameObject.FindWithTag("Player");
    }
 
    void Update()
    {
        Vector2 player1 = player.transform.position;
        Vector2 enemy1 = enemy.transform.position;
 
        if (Vector2.Distance(player1, enemy1) < 16)
        {
            enemy.transform.position = Vector2.MoveTowards(enemy1, player1, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}