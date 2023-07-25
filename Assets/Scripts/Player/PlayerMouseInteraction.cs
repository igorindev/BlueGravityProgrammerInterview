using UnityEngine;

public class PlayerMouseInteraction : MonoBehaviour
{
    readonly RaycastHit2D[] hitResults = new RaycastHit2D[1];

    [SerializeField] Transform mouseInteractionPresentationReference;
    [SerializeField] new Camera camera;
    [SerializeField] LayerMask LayerMask;

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
        if (value > 0)
        {
            isInteractable = hitResults[0].collider.TryGetComponent(out IInteractable interactable);
            currentInteraction = interactable;
        }
        else
        {
            currentInteraction = null;
        }

        SetInteractionPresentationActive(isInteractable);
        return isInteractable;
    }

    void Interact()
    {
        currentInteraction.StartInteraction();
    }

    void SetInteractionPresentationActive(bool value)
    {
        mouseInteractionPresentation.SetActive(value);
    }

    void SetInteractionPresentationInRangeActive(bool value)
    {

    }
}
