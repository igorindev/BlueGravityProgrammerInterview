using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5.0f;
    [SerializeField] Animator animator;
    [SerializeField] Transform mesh;

    Rigidbody2D playerRigidbody;

    readonly int animSpeed = Animator.StringToHash("Speed");

    Vector2 movementInput;

    bool movingRight;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        MovePlayer();
        animator.SetFloat(animSpeed, playerRigidbody.velocity.magnitude);
        RotateCharacterToDirection();
    }

    void MovePlayer()
    {
        playerRigidbody.velocity = movementInput.normalized * playerSpeed;
    }

    void RotateCharacterToDirection()
    {
        if (movementInput.x < 0 && movingRight == false)
        {
            movingRight = true;
            Invert();
        }
        else if (movementInput.x > 0 && movingRight == true)
        {
            movingRight = false;
            Invert();
        }

        void Invert()
        {
            Vector3 scale = mesh.localScale;
            scale.x *= -1;
            mesh.localScale = scale;
        }
    }

    public void SendInput(Vector2 input)
    {
        movementInput = input.x * Vector2.right + input.y * Vector2.up;
    }
}
