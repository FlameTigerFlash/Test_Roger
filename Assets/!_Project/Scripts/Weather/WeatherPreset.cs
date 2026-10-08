using UnityEngine;

[CreateAssetMenu(fileName = "WeatherPreset", menuName = "Weather/Weather Preset")]
public class WeatherPreset : ScriptableObject
{
    [field: SerializeField] public WeatherState State { get; private set; }

    [field: SerializeField, Range(0f, 360f)] public float WindDirection { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float WindForce { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float Intensity { get; private set; }
    [field: SerializeField, Range(0f, 1f)] public float FogDensity { get; private set; }
}