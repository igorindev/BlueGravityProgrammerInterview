using UnityEngine;

public class PlayerMouseInteraction : MonoBehaviour, IInput
{
    readonly RaycastHit2D[] hitResults = new RaycastHit2D[1];

    [SerializeField] Transform mouseInteractionPresentationReference;
    [SerializeField] new Camera camera;
    [SerializeField] LayerMask LayerMask;
    [SerializeField] float cellDistanceToEnableInput;

    Transform playerTransform;

    IMouseInteractionPresentation mouseInteractionPresentation;
    IInteractable currentInteraction;

    bool inputEnable = true;

    public bool InputEnable
    {
        get => inputEnable;
        set
        {
            inputEnable = value;
            if (!value)
            {
                SetInteractionPresentationActive(false);
            }
        }
    }

    public void Setup(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
    }

    void Start()
    {
        mouseInteractionPresentation = mouseInteractionPresentationReference.GetComponent<IMouseInteractionPresentation>();
    }

    void Update()
    {
        if (!InputEnable) { return; }

        if (TryFindInteractableEntity())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Interact();
            }
        }
    }

    bool TryFindInteractableEntity()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        int value = Physics2D.GetRayIntersectionNonAlloc(ray, hitResults, Mathf.Infinity, LayerMask);

        bool isInteractable = false;
        bool isInRange = false;
        if (value > 0)
        {
            isInteractable = hitResults[0].collider.TryGetComponent(out IInteractable interactable);
            isInRange = (playerTransform.position - hitResults[0].transform.position).sqrMagnitude <= cellDistanceToEnableInput * cellDistanceToEnableInput;
            currentInteraction = interactable;
        }
        else
        {
            currentInteraction = null;
        }

        SetInteractionPresentationActive(isInteractable);
        SetInteractionPresentationInRange(isInRange);
        return isInteractable && isInRange;
    }

    void Interact()
    {
        currentInteraction.StartInteraction();
    }

    void SetInteractionPresentationActive(bool value)
    {
        mouseInteractionPresentation.SetActive(value);
    }

    void SetInteractionPresentationInRange(bool value)
    {
        mouseInteractionPresentation.SetInteractive(value);
    }
}
