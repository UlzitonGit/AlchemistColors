using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource soundEffectSource;
    public AudioClip soundEffectClip;

    public void PlaySoundEffect()
    {
        soundEffectSource.PlayOneShot(soundEffectClip);
    }
}