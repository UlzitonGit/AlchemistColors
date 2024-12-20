using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Скорость движения игрока
    public float moveSpeed = 5f;

    // Флаг для отслеживания переворота
    private bool isFlipped = false;

    void Update()
    {
        // Проверка нажатия клавиш для всех направлений
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
    }

    private void MoveLeft()
    {
        transform.position -= Vector3.right * moveSpeed * Time.deltaTime;
        FlipX(true);
    }

    private void MoveRight()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        FlipX(false);
    }

    private void MoveUp()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    private void MoveDown()
    {
        transform.position -= Vector3.up * moveSpeed * Time.deltaTime;
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