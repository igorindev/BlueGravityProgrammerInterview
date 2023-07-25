using UnityEngine;
using UnityEngine.UI;

public interface IMouseInteractionPresentation
{
    public void SetActive(bool value);
    public void SetInteractive(bool isInRange);
}

public class MouseInteractionPresentation : MonoBehaviour, IMouseInteractionPresentation
{
    [SerializeField] Canvas parentCanvas;
    [SerializeField] Vector2 offsetPositionFromMouse = new Vector2(20, -80);
    
    Image interactionIcon;
    RectTransform myTransform;
    RectTransform rectTransform;

    void Start()
    {
        interactionIcon = GetComponent<Image>();
        rectTransform = parentCanvas.transform as RectTransform;
        myTransform = transform as RectTransform;
    }

    void Update()
    {
        SetPositionRelativeToMouse();
    }

    void SetPositionRelativeToMouse()
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, null, out Vector2 movePos);
        Vector3 pos = rectTransform.TransformPoint(movePos);
        pos += new Vector3(offsetPositionFromMouse.x, offsetPositionFromMouse.y, 0);
        myTransform.position = pos;
    }

    public void SetActive(bool value)
    {
        interactionIcon.enabled = value;
    }

    public void SetInteractive(bool isInRange)
    {
        interactionIcon.color = isInRange ? Color.white : new Color(1, 1, 1, 0.5f);
    }
}
