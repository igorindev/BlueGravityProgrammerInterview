using UnityEngine;

public class AudioUIButtons : MonoBehaviour
{
    [SerializeField] AudioClip normalClick;
    [SerializeField] AudioClip backClick;

    public enum ButtonClick
    {
        Normal,
        Back
    }

    public void PlayButtonClickAudio(ButtonClick buttonClick)
    {
        switch (buttonClick)
        {
            case ButtonClick.Normal:
                AudioManager.Instance.PlayAudio2D(normalClick);
                break;
            case ButtonClick.Back:
                AudioManager.Instance.PlayAudio2D(backClick);
                break;
        }
    }
}
