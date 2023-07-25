using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    public void PlayAudio()
    {
        AudioManager.Instance.PlayAudio2D(clip);
    }
}
