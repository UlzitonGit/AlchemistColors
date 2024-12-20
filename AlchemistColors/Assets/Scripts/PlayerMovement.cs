using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Скорость движения игрока
    public float moveSpeed = 5f;

    // Флаг для отслеживания переворота
    private bool isFlipped = false;
    Rigidbody2D rb;
    [SerializeField] Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        
        Move();
    }

   
    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
       
        
        FlipX(horizontal < 0);
        Vector2 move = new Vector2(horizontal, vertical);
        rb.velocity = move * moveSpeed;
       
        animator.SetBool("Move", move.magnitude > 0);
    }
    private void FlipX(bool flipped)
    {
        if (isFlipped != flipped)
        {
            isFlipped = flipped;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }
}