using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] Animator animator;

    Rigidbody2D playerRigidbody;

    readonly int animSpeed = Animator.StringToHash("Speed");

    Vector2 movementInput;

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
        playerRigidbody.velocity = movementInput.normalized * playerSpeed;
    }

    public void SendInput(Vector2 input)
    {
        movementInput = input.x * Vector2.right + input.y * Vector2.up;
    }
}
