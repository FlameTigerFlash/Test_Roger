using UnityEngine;

public class WindPresenter : MonoBehaviour
{
    [SerializeField] private WeatherSystem _windSystem;
    [SerializeField] private Transform _ship;
    [SerializeField] private WindDisplay _display;

    private void Update()
    {
        if (_windSystem == null || _display == null) return;

        _display.SetDirection(_windSystem.WindDirection);
        _display.SetForce(_windSystem.WindForce);
        _display.SetIntensity(_windSystem.Intensity);

        if (_ship == null) return;

        Vector3 shipForward = Vector3.ProjectOnPlane(_ship.forward, Vector3.up).normalized;
        Vector3 windForward = _windSystem.WindDirectionVector;

        float relativeAngle = Vector3.SignedAngle(shipForward, windForward, Vector3.up);
        _display.SetRelativeAngle(relativeAngle);
    }
}