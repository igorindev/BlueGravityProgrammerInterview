using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{
    public Canvas npcCanvas;

    public void StartInteraction()
    {
        UIHandler.PresentUI(npcCanvas);
    }

    public void StopInteraction()
    {
        
    }
}
