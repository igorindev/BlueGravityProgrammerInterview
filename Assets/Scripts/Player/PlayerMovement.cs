using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] Animator animator;

    Rigidbody2D playerRigidbody;

    readonly int animSpeed = Animator.StringToHash("Speed");

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        animator.SetFloat(animSpeed, playerRigidbody.velocity.magnitude);
    }

    void MovePlayer()
    {
        Vector2 horizontalInput = Input.GetAxisRaw("Horizontal") * Vector2.right + Input.GetAxisRaw("Vertical") * Vector2.up;
        playerRigidbody.velocity = horizontalInput.normalized * playerSpeed;
    }
}
