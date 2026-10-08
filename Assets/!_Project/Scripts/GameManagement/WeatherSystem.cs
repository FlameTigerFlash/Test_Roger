using System;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class WeatherSystem : MonoBehaviour
{
    [SerializeField, Range(0f, 360f)] private float _windDirection;
    [SerializeField, Range(0f, 1f)] private float _windForce;
    [SerializeField, Range(0f, 1f)] private float _intensity;

    public event Action OnWindChanged;

    public float WindDirection
    {
        get => _windDirection;
        set
        {
            float normalized = Mathf.Repeat(value, 360f);
            if (Mathf.Approximately(_windDirection, normalized)) return;
            _windDirection = normalized;
            OnWindChanged?.Invoke();
        }
    }

    public float WindForce
    {
        get => _windForce;
        set
        {
            float clamped = Mathf.Clamp01(value);
            if (Mathf.Approximately(_windForce, clamped)) return;
            _windForce = clamped;
            OnWindChanged?.Invoke();
        }
    }

    public float Intensity
    {
        get => _intensity;
        set
        {
            float clamped = Mathf.Clamp01(value);
            if (Mathf.Approximately(_intensity, clamped)) return;
            _intensity = clamped;
            OnWindChanged?.Invoke();
        }
    }

    public Vector3 WindDirectionVector =>
        Quaternion.Euler(0f, _windDirection, 0f) * Vector3.forward;

    private void OnValidate()
    {
        _windDirection = Mathf.Repeat(_windDirection, 360f);
        _windForce = Mathf.Clamp01(_windForce);
        OnWindChanged?.Invoke();
    }
}