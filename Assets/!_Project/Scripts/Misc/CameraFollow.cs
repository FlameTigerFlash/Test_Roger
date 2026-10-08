using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0f, 15f, -15f);
    [SerializeField] private float _positionSmoothTime = 0.15f;
    [SerializeField] private float _rotationSmoothSpeed = 5f;

    private Vector3 _velocity;

    private void LateUpdate()
    {
        if (_target == null) return;

        // Позиция: сглаженное следование за целью со смещением в мировых координатах.
        Vector3 desiredPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(
            transform.position,
            desiredPosition,
            ref _velocity,
            _positionSmoothTime);

        // Поворот: сглаженный разворот в сторону цели.
        Vector3 lookDirection = _target.position - transform.position;
        if (lookDirection.sqrMagnitude < 0.0001f) return;

        Quaternion desiredRotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            desiredRotation,
            _rotationSmoothSpeed * Time.deltaTime);
    }
}