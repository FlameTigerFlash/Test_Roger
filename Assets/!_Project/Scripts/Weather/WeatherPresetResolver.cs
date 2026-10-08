using UnityEngine;

public class WeatherPresetResolver : MonoBehaviour
{
    [SerializeField] private WeatherSystem _windSystem;
    [SerializeField] private WeatherPreset _currentPreset;

    public WeatherPreset CurrentPreset => _currentPreset;
    public WeatherState CurrentState => _currentPreset != null ? _currentPreset.State : default;

    private void Start()
    {
        ApplyWeather();
    }

    public void SetWeatherPreset(WeatherPreset preset)
    {
        _currentPreset = preset;
        ApplyWeather();
    }

    public void ApplyWeather()
    {
        if (_currentPreset == null || _windSystem == null) return;

        _windSystem.WindDirection = _currentPreset.WindDirection;
        _windSystem.WindForce = _currentPreset.WindForce;
        _windSystem.Intensity = _currentPreset.Intensity;

        RenderSettings.fog = true;
        RenderSettings.fogDensity = _currentPreset.FogDensity;
    }

    private void OnValidate()
    {
        if (Application.isPlaying)
            ApplyWeather();
    }
}