using UnityEngine;

public static class UIHandler
{
    public static void PresentUI(Canvas canvas)
    {
        canvas.enabled = true;

        //stop game systems that are not UI related
    }

    public static void HideUI(Canvas canvas)
    {
        canvas.enabled = false;

        //re enable game systems that are not UI related
    }
}
