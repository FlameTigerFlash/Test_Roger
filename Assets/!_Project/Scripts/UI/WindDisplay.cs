using TMPro;
using UnityEngine;

public class WindDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _directionLabel;
    [SerializeField] private TMP_Text _forceLabel;
    [SerializeField] private TMP_Text _relativeAngleLabel;
    [SerializeField] private TMP_Text _intensityLabel;
    [SerializeField] private RectTransform _windArrow;

    public void SetDirection(float degrees)
    {
        if (_directionLabel != null)
            _directionLabel.text = $"Wind direction: {degrees:F0}°";
    }

    public void SetForce(float force)
    {
        if (_forceLabel != null)
            _forceLabel.text = $"Wind strength: {force:F2}";
    }

    public void SetRelativeAngle(float degrees)
    {
        if (_relativeAngleLabel != null)
            _relativeAngleLabel.text = $"Relative angle: {degrees:F0}°";

        if (_windArrow != null)
            _windArrow.localRotation = Quaternion.Euler(0f, 0f, -degrees);
    }

    public void SetIntensity(float intensity)
    {
        if (_intensityLabel != null)
            _intensityLabel.text = $"Intensity: {intensity:F2}";
    }
}