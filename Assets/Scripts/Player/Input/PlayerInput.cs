using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    PlayerMovement playerMovement;

    bool inputEnable = true;
    public bool InputEnable { get => inputEnable; set => inputEnable = value; }

    public void Setup(Transform playerTransform)
    {
        playerMovement = playerTransform.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Vector2 input = default;
        if (InputEnable)
        {
            input = Input.GetAxisRaw("Horizontal") * Vector2.right + Input.GetAxisRaw("Vertical") * Vector2.up;
        }

        playerMovement.SendInput(input);
    }
}
