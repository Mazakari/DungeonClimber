using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Toggle _musicToggle;

    [Header("Sounds")]
    [SerializeField] private Slider _soundsVolumeSlider;
    [SerializeField] private Toggle _soundsToggle;

    private ISaveLoadService _saveLoadService;
    private VolumeControl _volumeControl;

    // TO DO save audio settings or OnDisable?
    [SerializeField] private Button _backButon;

    private void OnEnable()
    {
        _volumeControl = FindObjectOfType<VolumeControl>();
        _saveLoadService = AllServices.Container.Single<ISaveLoadService>();

        _musicVolumeSlider.onValueChanged.AddListener(HandleMusicVolume);
        _musicToggle.onValueChanged.AddListener(HandleMusicToggle);

        _soundsVolumeSlider.onValueChanged.AddListener(HandleSoundsVolume);
        _soundsToggle.onValueChanged.AddListener(HandleSoundsToggle);

        _backButon.onClick.AddListener(SaveAudioSettings);

        // load UI values from _audioService.VolumeControl.settings
        LoadAudioSettings();
    }

    private void OnDisable()
    {
        _musicVolumeSlider.onValueChanged.RemoveAllListeners();
        _musicToggle.onValueChanged.RemoveAllListeners();

        _soundsVolumeSlider.onValueChanged.RemoveAllListeners();
        _soundsToggle.onValueChanged.RemoveAllListeners();

        _backButon.onClick.RemoveAllListeners();
    }

    private void HandleMusicVolume(float value)
    {
        value = _musicVolumeSlider.value;
        _volumeControl.HandleMusicSliderValueChanged(value, _musicVolumeSlider, _musicToggle);
    }

    private void HandleMusicToggle(bool value) =>
        _volumeControl.HandleMusicToggleChanged(value, _musicVolumeSlider, _musicToggle);

    private void HandleSoundsVolume(float value)
    {
        value = _soundsVolumeSlider.value;
        _volumeControl.HandleSoundsSliderValueChanged(value, _soundsVolumeSlider, _soundsToggle);
    }

    private void HandleSoundsToggle(bool value) =>
       _volumeControl.HandleSoundsToggleChanged(value, _soundsVolumeSlider, _soundsToggle);

    private void LoadAudioSettings()
    {
        _musicVolumeSlider.value = _volumeControl.MusicVolume;
        _musicToggle.isOn = _volumeControl.MusicOn;

        _soundsVolumeSlider.value = _volumeControl.SoundsVolume;
        _soundsToggle.isOn = _volumeControl.SoundsOn;
    }

    private void SaveAudioSettings() =>
       _saveLoadService.SaveProgress();
}
