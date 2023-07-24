using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;

    Rigidbody2D playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        Vector2 horizontalInput = Input.GetAxisRaw("Horizontal") * Vector2.right + Input.GetAxisRaw("Vertical") * Vector2.up;
        playerRigidbody.velocity = horizontalInput.normalized * playerSpeed;
    }
}
