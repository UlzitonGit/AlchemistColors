using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider soundEffectsVolumeSlider;

    public AudioMixer audioMixer;

    private const string MUSIC_VOLUME_KEY = "music_volume";
    private const string SOUND_EFFECTS_VOLUME_KEY = "sound_effects_volume";

    private void Start()
    {
        // Загружаем сохранённые значения
        musicVolumeSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
        soundEffectsVolumeSlider.value = PlayerPrefs.GetFloat(SOUND_EFFECTS_VOLUME_KEY, 1f);

        // Применяем загруженные значения к аудио микшеру
        ApplyVolumeChanges();
    }

    public void ApplyVolumeChanges()
    {
        SetMusicVolume(musicVolumeSlider.value);
        SetSoundEffectsVolume(soundEffectsVolumeSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        // Ограничиваем значение, чтобы избежать делений на ноль
        volume = Mathf.Max(volume, 0.0001f);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
    }

    public void SetSoundEffectsVolume(float volume)
    {
        // Ограничиваем значение, чтобы избежать делений на ноль
        volume = Mathf.Max(volume, 0.0001f);
        audioMixer.SetFloat("SoundEffectsVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(SOUND_EFFECTS_VOLUME_KEY, volume);
    }
}