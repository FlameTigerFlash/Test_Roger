using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [SerializeField] private WeatherSystem _windSystem;
    [SerializeField] private float _baseSpeed = 3f;
    [SerializeField] private float _maxSpeed = 10f;
    [SerializeField] private float _windBoost = 5f;
    [SerializeField] private float _turnSpeed = 90f;

    private float _turnInput;

    private void Update()
    {
        ApplyTurn(_turnInput);
        ApplyMovement();
    }

    public void OnTurnInput(InputAction.CallbackContext context)
    {
        _turnInput = context.ReadValue<float>();
    }

    private void ApplyTurn(float input)
    {
        transform.Rotate(0f, input * _turnSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void ApplyMovement()
    {
        Vector3 shipForward = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

        float speed = _baseSpeed;
        if (_windSystem != null)
        {
            float cos = Vector3.Dot(shipForward, _windSystem.WindDirectionVector);
            if (cos > 0f)
                speed += _windSystem.WindForce * _windBoost * cos;
        }

        speed = Mathf.Min(speed, _maxSpeed);
        transform.position += shipForward * speed * Time.deltaTime;
    }
}