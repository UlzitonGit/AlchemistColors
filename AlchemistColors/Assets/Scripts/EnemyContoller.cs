using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyContoller : MonoBehaviour
{
    GameObject rune;
    public string color;
    private GameObject player;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speed;
    [SerializeField] EnemyTypes[] enemyTypes;
    [SerializeField] GameObject deathPart;
    [SerializeField] Transform amuletPos;
    void Start()
    {   
        int randomEnemyType = Random.Range(0, enemyTypes.Length);
        Instantiate(enemyTypes[randomEnemyType].rune, amuletPos);
        color = enemyTypes[randomEnemyType].color;
        player = GameObject.FindWithTag("Player");
    }
 
    void Update()
    {
        Vector2 player1 = player.transform.position;
        Vector2 enemy1 = enemy.transform.position;
        if(player.transform.position.x > enemy.transform.position.x) gameObject.transform.localScale = new Vector3(-1,1,1);
        else gameObject.transform.localScale = new Vector3(1, 1, 1);
        if (Vector2.Distance(player1, enemy1) < 50)
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
        if (collision.gameObject.tag == "Bullet" && collision.gameObject.GetComponent<PlayerBullet>().color == color) 
        {
            Instantiate(deathPart, transform.position, Quaternion.Euler(0,0,60));
            Destroy(gameObject);
        }
    }
}