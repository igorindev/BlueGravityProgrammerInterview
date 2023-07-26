using UnityEngine;

public class AudioUIButtons : MonoBehaviour
{
    [SerializeField] AudioClip normalClick;

    public enum ButtonClick
    {
        Normal,
    }

    public void PlayButtonClickAudio(ButtonClick buttonClick)
    {
        switch (buttonClick)
        {
            case ButtonClick.Normal:
                AudioManager.Instance.PlayAudio2D(normalClick);
                break;
        }
    }
}
